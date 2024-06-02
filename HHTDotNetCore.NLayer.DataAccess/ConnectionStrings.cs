using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHTDotNetCore.NLayer.DataAccess
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-QNI7OO1",
            InitialCatalog = "DotNEtTrainingBatch4",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };
    }
}
