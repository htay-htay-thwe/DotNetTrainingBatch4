using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HHTDotNetCore.shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;
        public AdoDotNetService(string connectionString)        {
            _connectionString = connectionString;
        }

        public T QueryFitstOrDefault<T>(string query,params AdoDotNetParameter[]? parameters ) {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach (var item in Parameters)
                //{
                //    cmd.Parameters.addwithvalue(item.Name, item.Vlue);

                //}
                //cmd.Parameters.clear();
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }
               
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt);
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!;
            return lst[0];
        }

    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter()
        {

        }
        public AdoDotNetParameter(string name,object value)
        {
            Name = name;
            Value = value;  
        }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
