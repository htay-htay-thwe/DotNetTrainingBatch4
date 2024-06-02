
using System.Data.SqlClient;

namespace HHTDotNetCore.WinFormAppSqlInjection
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-QNI7OO1",
            InitialCatalog = "DotNEtTrainingBatch4",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };
    }
}
