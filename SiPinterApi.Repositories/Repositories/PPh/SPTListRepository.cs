using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SiPinterApi.Domain.Entities.PPh;
using SiPinterApi.Infrastructure.Dapper;
using Dapper;

namespace SiPinterApi.Repositories.PPh
{
    public class SPTListRepository : BaseRepository, ISPTListRepository
    {
        public SPTListRepository(IDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<List<SPT>> GetListSPT(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyCode", CompanyCode, DbType.String);
            parameters.Add("Npwp", Npwp, DbType.String);
            parameters.Add("Masa", Masa, DbType.String);
            parameters.Add("Tahun", Tahun, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<SPT>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<SPTHeader> GetSptHeaderById(int id)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("IdSptHeader", id, DbType.Int32);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.Get<SPTHeader>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }
    }
}
