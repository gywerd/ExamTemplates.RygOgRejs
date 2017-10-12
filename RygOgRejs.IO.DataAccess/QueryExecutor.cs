using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.IO.DataAccess.General
{
    public class QueryExecutor
    {
        #region Fields
        private string connectionString;
        #endregion

        #region Methods
        public DataSet Execute(string sqlQuery)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataSet set = new DataSet();
                adapter.Fill(set); // Fix Emil
                connection.Close();
                return set;
            }

        }

        public void ExecuteNonQuery(string sqlQuery)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close(); //not sure if needed but im doing it anyway
        }

        //something will be added useless for now
        public DataSet Execute(SqlCommand command)
        {
            return null;
        }

        public QueryExecutor()
        {
            connectionString = GetConnectionString();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();
            }
            catch (SqlException) { throw; }


        }

        //static for life Keepo
        private static string GetConnectionString()
        {
            return @"Data Source=10.205.44.39,49172;Initial Catalog=RygOgRejs;Persist Security Info=True;User ID=Aspit;Password=Server2012";
        }
        #endregion
    }
}
