using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class IODB
    {
        private SqlConnection connection;

        private IODB(SqlConnection connection)
        {
            this.connection = connection;
        }

        public static IODB Connect(string connectionString)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                return new IODB(con);
            }
            catch
            {
                throw new Exception("Erro ao Conectar com o banco de dados.");
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public void Execute(string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.ExecuteNonQuery(); 
        }

        public SqlDataReader ExecuteReturnReader(string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            return command.ExecuteReader();
        }

        public DataTable ExecuteReturnTable(string queryString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(queryString, connection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
