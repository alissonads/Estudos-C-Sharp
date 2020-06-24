using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    /**
     * Gerenciador Generico de dados.
     * Basta passar um tipo ao instanciar um objeto dessa classe.
     *
     * Busca dados do banco;
     * Salva dados no banco;
     * Exclui dados do banco;
    */
    public sealed class GerenciadorDeDados<T>
    {
        private string connectionString = ConfigurationManager.AppSettings["SqlConnection"];
        
        /*
         * Busca todos os campos de uma tabela no banco
        */
        public List<T> Buscar()
        {
            var objetos = new List<T>();
            var iodb = IODB.Connect(connectionString);
            string queryString = "select * from " + getNomeTabela(typeof(T));
            SqlDataReader reader = iodb.ExecuteReturnReader(queryString);

            while (reader.Read())
            {
                var obj = (T)Activator.CreateInstance(typeof(T));
                setPropriedade(obj, reader);
                objetos.Add(obj);
            }
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    string queryString = "select * from " + getNomeTabela(typeof(T));
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();

            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        var obj = (T)Activator.CreateInstance(typeof(T));
            //        setPropriedade(obj, reader);
            //        objetos.Add(obj);
            //    }
            //}
            iodb.Close();

            return objetos;
        }

        /*
         * Busca todos os campos de uma tabela no banco
         * de acordo com as propriedades listadas como
         * UsarParaBuscar da class de assinatura OpcoesBase
        */
        public List<T> Buscar(T obj)
        {
            var objectos = new List<T>();
            var iodb = IODB.Connect(connectionString);
            List<string> where = new List<string>();
            string chavePrimaria = string.Empty;

            var propriedades = getPropriedades(typeof(T));
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
                        var valor = item.GetValue(obj);
                        if (valor != null)
                        {
                            where.Add(item.Name + " = '" + valor + "'");
                        }
                    }
                }
            }

            var queryString = "select * from " + getNomeTabela(typeof(T)) +
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
                var aux = (T)Activator.CreateInstance(obj.GetType());
                setPropriedade(aux, reader);
                objectos.Add(aux);
            }

            iodb.Close();

            return objectos;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> where = new List<string>();
            //    string chavePrimaria = string.Empty;

            //    var propriedades = getPropriedades(typeof(T));
            //    OpcoesBase opBase = null;
            //    foreach (PropertyInfo item in propriedades)
            //    {
            //        opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

            //        if (opBase != null)
            //        {
            //            if (opBase.ChavePrimaria)
            //            {
            //                chavePrimaria = item.Name;
            //            }
            //            if (opBase.UsarParaBuscar)
            //            {
            //                var valor = item.GetValue(obj);
            //                if (valor != null)
            //                {
            //                    where.Add(item.Name + " = '" + valor + "'");
            //                }
            //            }
            //        }
            //    }

            //    var queryString = "select * from " + getNomeTabela(typeof(T)) +
            //                      " where " + chavePrimaria + " is not null ";

            //    if (where.Count > 0)
            //    {
            //        queryString += "and " + string.Join(" and ", where);
            //    }
            //    else
            //    {
            //        throw new Exception("Para realizar a busca do(s) item(s), necessita-se de uma CHAVE referente ao objto NÃO NULA.");
            //    }

            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();

            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        var aux = (T)Activator.CreateInstance(obj.GetType());
            //        setPropriedade(aux, reader);
            //        objectos.Add(aux);
            //    }
            //}

            //return objectos;
        }

        /*
         * Busca os dados de um objeto pelo seu identificador
         * e atualiza esse objeto
         */
        public void Atualizar(T obj)
        {
            var iodb = IODB.Connect(connectionString);
            List<string> where = new List<string>();
            string nomeChavePrimaria = string.Empty;
            string valorChavePrimaria = string.Empty;

            var propriedades = getPropriedades(typeof(T));

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

            var queryString = "select * from " + getNomeTabela(typeof(T));

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
                setPropriedade(obj, reader);
            }

            iodb.Close();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> where = new List<string>();
            //    string nomeChavePrimaria = string.Empty;
            //    string valorChavePrimaria = string.Empty;

            //    var propriedades = getPropriedades(typeof(T));

            //    foreach (PropertyInfo item in propriedades)
            //    {
            //        OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

            //        if (opBase != null)
            //        {
            //            if (opBase.ChavePrimaria)
            //            {
            //                nomeChavePrimaria = item.Name;
            //                valorChavePrimaria = item.GetValue(this).ToString();
            //            }
            //        }
            //    }

            //    var queryString = "select * from " + getNomeTabela(typeof(T));

            //    if (!string.IsNullOrEmpty(nomeChavePrimaria) &&
            //        !string.IsNullOrEmpty(valorChavePrimaria))
            //    {
            //        queryString += " where " + nomeChavePrimaria + " = '" + valorChavePrimaria + "'";
            //    }
            //    else
            //    {
            //        throw new Exception("Para realizar a busca do item, necessita-se de uma CHAVE PRIMÁRIA NÃO NULA.");
            //    }

            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();

            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        setPropriedade(obj, reader);
            //    }
            //}
        }

        /*
         * Exclui um registro no banco atraves do identificador do objeto
         */
        public void Excluir(T obj)
        {
            var iodb = IODB.Connect(connectionString);
            List<string> where = new List<string>();

            var propriedades = getPropriedades(typeof(T));
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null)
                {
                    if (opBase.ChavePrimaria || opBase.UsarParaBuscar)
                    {
                        var valor = item.GetValue(this);
                        if (valor != null)
                            where.Add(item.Name + " = '" + item.GetValue(obj) + "'");
                    }
                }
            }

            var queryString = "delete from " + getNomeTabela(typeof(T));

            if (where.Count > 0)
                queryString += " where " + string.Join("and ", where);

            iodb.Execute(queryString);
            iodb.Close();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> where = new List<string>();

            //    var propriedades = getPropriedades(typeof(T));
            //    foreach (PropertyInfo item in propriedades)
            //    {
            //        OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

            //        if (opBase != null)
            //        {
            //            if (opBase.ChavePrimaria || opBase.UsarParaBuscar)
            //            {
            //                var valor = item.GetValue(this);
            //                if (valor != null)
            //                    where.Add(item.Name + " = '" + item.GetValue(obj) + "'");
            //            }
            //        }
            //    }

            //    var queryString = "delete from " + getNomeTabela(typeof(T));

            //    if (where.Count > 0)
            //        queryString += " where " + string.Join("and ", where);

            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();
            //    command.ExecuteNonQuery();
            //}
        }

        /*
         * Salva o objeto no banco
         */
        public void Salvar(T obj)
        {
            var iodb = IODB.Connect(connectionString);
            List<string> campos = new List<string>();
            List<string> valores = new List<string>();

            var propriedades = getPropriedades(typeof(T));
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null)
                {
                    if (opBase.UsarBancoDados && !opBase.AutoIncrementa)
                    {
                        campos.Add(item.Name);
                        valores.Add("'" + item.GetValue(obj) + "'");
                    }
                }
            }

            var queryString = "insert into " + getNomeTabela(typeof(T)) + " (" + string.Join(", ", campos) + ") " +
                              "values (" + string.Join(", ", valores) + ")";
            iodb.Execute(queryString);
            iodb.Close();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> campos = new List<string>();
            //    List<string> valores = new List<string>();

            //    var propriedades = getPropriedades(typeof(T));
            //    foreach (PropertyInfo item in propriedades)
            //    {
            //        OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

            //        if (opBase != null)
            //        {
            //            if (opBase.UsarBancoDados && !opBase.AutoIncrementa)
            //            {
            //                campos.Add(item.Name);
            //                valores.Add("'" + item.GetValue(obj) + "'");
            //            }
            //        }
            //    }

            //    var queryString = "insert into " + getNomeTabela(typeof(T)) + " (" + string.Join(", ", campos) + ") " +
            //                      "values (" + string.Join(", ", valores) + ")";
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();
            //    command.ExecuteNonQuery();
            //}
        }
        
        private void setPropriedade(T obj, SqlDataReader reader)
        {
            var propriedades = getPropriedades(typeof(T));
            foreach (PropertyInfo item in propriedades)
            {
                OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                if (opBase != null && opBase.UsarBancoDados && reader[item.Name] != DBNull.Value)
                {
                    item.SetValue(obj, reader[item.Name]);
                }
            }
        }

        private PropertyInfo[] getPropriedades(Type tipo)
        {
            return tipo.GetProperties(BindingFlags.Public |
                                      BindingFlags.Instance |
                                      BindingFlags.NonPublic);
        }

        //Pegar a assinatura do Nome da tabela
        private string getNomeTabela(Type tipo)
        {
            var info = getInfo(tipo);
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

        private TypeInfo getInfo(Type tipo)
        {
            return tipo.GetTypeInfo();
        }
    }
}
