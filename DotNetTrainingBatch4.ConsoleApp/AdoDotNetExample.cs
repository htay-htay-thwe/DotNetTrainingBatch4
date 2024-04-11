using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
         DataSource = "DESKTOP-QNI7OO1",
         InitialCatalog =  "DotNEtTrainingBatch4",
         UserID = "sa",
         Password = "sasa@123",
        };

        public void Read()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
 
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
            connection.Open();
            string query = "select * from table_1";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id =>" + dr["BlodId"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("--------------------------");

            }
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Table_1]
       ([BlogTitle]
           , [BlogAuthor]
           , [BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.Write(message);
        }
    }
}
