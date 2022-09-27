using Dapper;
using SiPinterApi.Domain;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;
using SiPinterApi.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SiPinterApi.Repositories.PPh
{
    public class MasterDataRepository : BaseRepository, IMasterDataRepository
    {
        public MasterDataRepository(IDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<MasterData.Config> GetValueConfigSPT(string ConfigName)
        {
            string ConStringType = "ConnectionStringSPT";
            var query = "USP_GET_KEY_VALUE_BASED_CONFIGNAME";
            var parameters = new DynamicParameters();
            parameters.Add("configName", ConfigName, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.Get<MasterData.Config>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<MasterData.Config> GetValueConfigH2H(string ConfigName)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("ConfigName", ConfigName, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.Get<MasterData.Config>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<List<MasterData.Company>> GetCompanyCode()
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<MasterData.Company>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<List<MasterData.Company>> GetNpwpBasedCompany(string CompanyCode)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyCode", CompanyCode, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<MasterData.Company>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<List<MasterData.Company>> GetNpwpBasedUser(string UserId)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", UserId, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<MasterData.Company>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }
    }
}
