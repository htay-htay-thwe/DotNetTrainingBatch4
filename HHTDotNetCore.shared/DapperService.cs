﻿using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace HHTDotNetCore.shared
{
    public class DapperService
    {
        private readonly string _connectionString;
        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<M> Query<M>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if(param != null)
            //{
            //    var lst = db.Query<M>(query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<M>(query).ToList();
            //}
            var lst = db.Query<M>(query).ToList();
            return lst;
        }
        public M QueryFirstOrDefault<M>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if(param != null)
            //{
            //    var lst = db.Query<M>(query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<M>(query).ToList();
            //}
            var lst = db.Query<M>(query,param).FirstOrDefault();
            return lst!;
        }

        public int Execute(string query,object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Execute(query, param);
        }
    }
}
