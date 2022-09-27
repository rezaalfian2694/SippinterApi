using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace SiPinterApi.Infrastructure.Dapper
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _config;
        //private string ConnectionstringSPT = "ConnectionStringSPT";
        //private string ConnectionstringH2H = "ConnectionStringH2H";

        public DbContext(IConfiguration config)
        {
            _config = config;
        }

        public void Dispose()
        {

        }

        public DbConnection GetDbConnection(string ConnectionStringType)
        {
            return new SqlConnection(_config.GetConnectionString(ConnectionStringType));
        }

        public int Execute(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionStringType));
            int result = db.Execute(sp, parms, commandType: commandType);
            return result;
        }

        public T Get<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionStringType));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionStringType));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public DataTable table(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.Text)
        {
            DataTable table = new DataTable("MyTable");
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionStringType));
            var reader = db.ExecuteReader(sp, parms, commandType: commandType);
            table.Load(reader);
            return table;
        }

        public T Insert<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionStringType));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionStringType));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
    }
}
