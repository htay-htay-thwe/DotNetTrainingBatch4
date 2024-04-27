
/*using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "DESKTOP-QNI7OO1";
stringBuilder.InitialCatalog = "DotNEtTrainingBatch4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sasa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
string query = "select * from table_1";
SqlCommand cmd =new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt =new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id =>" + dr["BlodId"]);
    Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
    Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
    Console.WriteLine("--------------------------");

}
Console.ReadKey();
*/
/*using DotNetTrainingBatch4.ConsoleApp;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();
adoDotNetExample.Create("title", "author", "content");
adoDotNetExample.Update(1, "test title", "test author", "test content");
adoDotNetExample.Delete(1);
adoDotNetExample.Edit(3);
Console.ReadLine();*/
using HHTDotNetCore.ConsoleApp;

DapperExample dapperExample = new DapperExample();
dapperExample.Run();


