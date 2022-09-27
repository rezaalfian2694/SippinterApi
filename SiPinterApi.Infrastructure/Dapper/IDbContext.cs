using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SiPinterApi.Infrastructure.Dapper
{
    public interface IDbContext : IDisposable
    {
        DbConnection GetDbConnection(string ConnectionStringType);
        T Get<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure);
        DataTable table(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.Text);
        int Execute(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, string ConnectionStringType, CommandType commandType = CommandType.StoredProcedure);
    }
}
