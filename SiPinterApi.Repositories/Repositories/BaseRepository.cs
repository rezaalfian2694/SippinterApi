using Microsoft.Extensions.Configuration;
using SiPinterApi.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SiPinterApi.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IDbContext _context;

        protected BaseRepository(IDbContext dbContext)
        {
            _context = dbContext;
        }

        protected IDbContext DbContext(string ConnectionStringType)
        {
            _context.GetDbConnection(ConnectionStringType);
            return _context;
        }

        protected IDbConnection DbConnection(string ConnectionStringType)
        {
            return _context.GetDbConnection(ConnectionStringType);
        }
    }
}
