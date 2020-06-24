using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;

namespace DataBase
{
    public abstract class Base : IBase
    {
        private string connectionString = ConfigurationManager.AppSettings["SqlConnection"];

        public string Key
        {
            get
            {
                var propriedades = getPropriedade();
                foreach (PropertyInfo item in propriedades)
                {
                    OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                    if (opBase != null && opBase.ChavePrimaria)
                        return Convert.ToString(item.GetValue(this));
                }

                return null;
            }
        }

        public void Atualizar()
        {
            var iodb = IODB.Connect(connectionString);
            List<string> where = new List<string>();
            string nomeChavePrimaria = string.Empty;
            string valorChavePrimaria = string.Empty;

            var propriedades = getPropriedade();
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null)
                {
                    if (opBase.ChavePrimaria)
                    {
                        nomeChavePrimaria = item.Name;
                        valorChavePrimaria = item.GetValue(this).ToString();
                    }
                }
            }

            var queryString = "select * from " + getNomeTabela();

            if (!string.IsNullOrEmpty(nomeChavePrimaria) &&
                !string.IsNullOrEmpty(valorChavePrimaria))
            {
                queryString += " where " + nomeChavePrimaria + " = '" + valorChavePrimaria + "'";
            }
            else
            {
                throw new Exception("Para realizar a busca do item, necessita-se de uma CHAVE PRIMÁRIA NÃO NULA.");
            }

            SqlDataReader reader = iodb.ExecuteReturnReader(queryString);
            while (reader.Read())
            {
                setPropriedade(this, reader);
            }

            iodb.Close();
        }

        public List<IBase> Buscar()
        {
            var aux = new List<IBase>();
            var iodb = IODB.Connect(connectionString);
            List<string> where = new List<string>();
            string chavePrimaria = string.Empty;

            var propriedades = getPropriedade();
            OpcoesBase opBase = null;
            foreach (PropertyInfo item in propriedades)
            {
                opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null)
                {
                    if (opBase.ChavePrimaria)
                    {
                        chavePrimaria = item.Name;
                    }
                    if (opBase.UsarParaBuscar)
                    {
                        var valor = item.GetValue(this);
                        if (valor != null)
                        {
                            where.Add(item.Name + " = '" + valor + "'");
                        }
                    }
                }
            }

            var queryString = "select * from " + getNomeTabela() +
                              " where " + chavePrimaria + " is not null ";

            if (where.Count > 0)
            {
                queryString += "and " + string.Join(" and ", where);
            }
            else
            {
                throw new Exception("Para realizar a busca do(s) item(s), necessita-se de uma CHAVE referente ao objto NÃO NULA.");
            }

            SqlDataReader reader = iodb.ExecuteReturnReader(queryString);
            while (reader.Read())
            {
                var obj = (IBase)Activator.CreateInstance(this.GetType());
                setPropriedade(obj, reader);
                aux.Add(obj);
            }

            iodb.Close();

            return aux;
        }

        public virtual List<IBase> BuscarTodos()
        {
            var aux = new List<IBase>();
            var iodb = IODB.Connect(connectionString);
            string queryString = "select * from " + getNomeTabela();

            SqlDataReader reader = iodb.ExecuteReturnReader(queryString);
            while (reader.Read())
            {
                var obj = (IBase)Activator.CreateInstance(this.GetType());
                setPropriedade(obj, reader);
                aux.Add(obj);
            }

            iodb.Close();

            return aux;
        }

        public virtual void Excluir()
        {
            var iodb = IODB.Connect(connectionString);
            List<string> where = new List<string>();

            var propriedades = getPropriedade();
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null)
                {
                    if (opBase.ChavePrimaria || opBase.UsarParaBuscar)
                    {
                        var valor = item.GetValue(this);
                        if (valor != null)
                            where.Add(item.Name + " = '" + item.GetValue(this) + "'");
                    }
                }
            }

            var queryString = "delete from " + getNomeTabela();

            if (where.Count > 0)
                queryString += " where " + string.Join("and ", where);

            iodb.Execute(queryString);
            iodb.Close();
        }

        public void Salvar()
        {
            var iodb = IODB.Connect(connectionString);
            List<string> atributos = new List<string>();
            List<string> valores = new List<string>();

            var propriedades = getPropriedade();
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null && opBase.UsarBancoDados && !opBase.AutoIncrementa)
                {
                    if (string.IsNullOrEmpty(this.Key))
                    {
                        atributos.Add(item.Name);
                        valores.Add(!opBase.ChavePrimaria ? 
                                    "'" + verificarValor(item) + "'" :
                                   "'" + (new GeradorCodigo(BuscarUltimoId().ToString())).Gerar(opBase.Max) + "'");
                    }
                    else
                    {
                        if (opBase.ChavePrimaria)
                            atributos.Add(item.Name + " = '" + item.GetValue(this) + "'");
                        else
                            valores.Add(item.Name + " = '" + verificarValor(item) + "'");
                    }

                }
            }

            var queryString = "insert into " + getNomeTabela() + " (" + string.Join(", ", atributos) + ") " +
                              "values (" + string.Join(", ", valores) + ")";

            if (!string.IsNullOrEmpty(this.Key) && this.Key != "0")
            {
                queryString = "update " + getNomeTabela() + " set " + string.Join(", ", valores) +
                              " where " + string.Join(" and ", atributos);
            }

            iodb.Execute(queryString);
            iodb.Close();
        }

        private object BuscarUltimoId()
        {
            var iodb = IODB.Connect(connectionString);
            var propriedades = getPropriedade();
            string chavePrimaria = string.Empty;

            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null && opBase.ChavePrimaria)
                {
                    chavePrimaria = item.Name;
                }
            }

            string queryString = "select top(1)" + chavePrimaria + " from " + getNomeTabela() +
                                 " where " + chavePrimaria + " is not null " +
                                 "order by " + chavePrimaria + " desc";
            
            DataRow dr = iodb.ExecuteReturnTable(queryString).Rows[0];
            iodb.Close();

            return dr[0];
        }

        private PropertyInfo[] getPropriedade()
        {
            return this.GetType().GetProperties(BindingFlags.Public   | 
                                                BindingFlags.Instance | 
                                                BindingFlags.NonPublic);
        }

        private TypeInfo getInfo()
        {
            return this.GetType().GetTypeInfo();
        }

        //Pegar a assinatura do Nome da tabela
        private string getNomeTabela()
        {
            var info = getInfo();
            OpcoesBase opBase = (OpcoesBase)info.GetCustomAttribute(typeof(OpcoesBase));
            if (opBase != null)
            {
                if (!string.IsNullOrEmpty(opBase.NomeTabela))
                {
                    return opBase.NomeTabela;
                }
            }
            return this.GetType().Name + "s";
        }

        private void setPropriedade(IBase obj, SqlDataReader reader)
        {
            var propriedades = getPropriedade();
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null && opBase.UsarBancoDados && reader[item.Name] != DBNull.Value)
                {
                    item.SetValue(obj, reader[item.Name]);
                }
            }
        }

        /*
         * Verifica se o tipo da propriedade é double ou decimal.
         * Se for faz os devidos ajustes e retorna a string modificada.
         * Se não retorna o valor.
         */
        private string verificarValor(PropertyInfo item)
        {
            if (item.PropertyType.Name == "Double" || item.PropertyType.Name == "Decimal")
                return  item.GetValue(this).ToString().Replace(".", "").Replace(",", ".");
            
            return item.GetValue(this).ToString();
        }
    }
}
