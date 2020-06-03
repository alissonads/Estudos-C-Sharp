using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;

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
            throw new NotImplementedException();
        }

        public void Buscar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> where = new List<string>();
                string chavePrimaria = string.Empty;
                string nomeTabela = this.GetType().Name + "s";

                var propriedades = getPropriedade();
                foreach (PropertyInfo item in propriedades)
                {
                    OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                    if (opBase != null)
                    {
                        if (opBase.ChavePrimaria)
                        {
                            chavePrimaria = item.Name;
                        }
                        if (opBase.UsarParaBuscar || opBase.ChavePrimaria)
                        {
                            var valor = item.GetValue(this);
                            if (valor != null)
                            {
                                where.Add(item.Name + " = '" + valor + "'");
                            }
                        }
                        if (!string.IsNullOrEmpty(opBase.NomeTabela))
                        {
                            nomeTabela = Convert.ToString(item.GetValue(this));
                        }
                    }
                }

                var queryString = "select * from " + nomeTabela +
                                  " where " + chavePrimaria + " is not null ";

                if (where.Count > 0)
                {
                    queryString += "and " + string.Join(" and ", where);
                }
                else
                {
                    throw new Exception("Para realizar a busca do item, necessita-se de uma CHAVE PRIMÁRIA NÃO NULA.");
                }

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    setPropriedade(this, reader);
                }
            }
        }

        public List<IBase> BuscarTodos()
        {
            var aux = new List<IBase>();
            string nomeTabela = this.GetType().Name + "s";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var propriedades = getPropriedade();
                foreach (PropertyInfo item in propriedades)
                {
                    OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                    if (opBase != null && !string.IsNullOrEmpty(opBase.NomeTabela))
                    {
                        nomeTabela = Convert.ToString(item.GetValue(this));
                    }
                }

                string queryString = "select * from " + nomeTabela;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setPropriedade(obj, reader);
                    aux.Add(obj);
                }
            }
            return aux;
        }

        //public static List<IBase> BuscarTodos(Type tipo)
        //{
        //    var aux = new List<IBase>();
        //    string nomeTabela = tipo.Name + "s";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        var propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        //        foreach (PropertyInfo item in propriedades)
        //        {
        //            OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

        //            if (opBase != null && !string.IsNullOrEmpty(opBase.NomeTabela))
        //            {
        //                nomeTabela = Convert.ToString(item.GetValue(tipo));
        //            }
        //        }

        //        string queryString = "select * from " + nomeTabela;
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var obj = (IBase)Activator.CreateInstance(tipo);
        //            setPropriedade(obj, reader);
        //            aux.Add(obj);
        //        }
        //    }
        //    return aux;
        //}

        public virtual void Excluir()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> where = new List<string>();
                string nomeTabela = this.GetType().Name + "s";

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
                        else if (!string.IsNullOrEmpty(opBase.NomeTabela))
                        {
                            nomeTabela = Convert.ToString(item.GetValue(this));
                        }
                    }
                }

                var queryString = "delete from " + nomeTabela;

                if (where.Count > 0)
                    queryString += " where " + string.Join("and ", where);

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Salvar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> campos = new List<string>();
                List<string> valores = new List<string>();
                string nomeTabela = this.GetType().Name + "s";

                var propriedades = getPropriedade();
                foreach (PropertyInfo item in propriedades)
                {
                    OpcoesBase opBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));

                    if (opBase != null)
                    {
                        if (opBase.UsarBancoDados && !opBase.AutoIncrementa)
                        {
                            campos.Add(item.Name);
                            valores.Add("'" + item.GetValue(this) + "'");
                        }
                        else if (!string.IsNullOrEmpty(opBase.NomeTabela))
                        {
                            nomeTabela = Convert.ToString(item.GetValue(this));
                        }
                    }
                }
                
                var queryString = "insert into " + nomeTabela + " (" + string.Join(", ", campos) + ") " +
                                  "values (" + string.Join(", ", valores) + ")";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private PropertyInfo[] getPropriedade()
        {
            return this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
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
                    //item.SetValue(obj, Convert.ChangeType(reader[item.Name], item.GetValue(this).GetType()));
                }
            }
        }
    }
}
