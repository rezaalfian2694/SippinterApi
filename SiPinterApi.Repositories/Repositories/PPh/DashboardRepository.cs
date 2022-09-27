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
    public class DashboardRepository: BaseRepository, IDashboardRepository
    {
        public DashboardRepository(IDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<List<Dashboard.IndexDashboard>> GetIndexDashboard(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyCode", CompanyCode, DbType.String);
            parameters.Add("Npwp", Npwp, DbType.String);
            parameters.Add("Masa", Masa, DbType.String);
            parameters.Add("Tahun", Tahun, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<Dashboard.IndexDashboard>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<List<Dashboard.Detail>> GetDetailDashboard(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyCode", CompanyCode, DbType.String);
            parameters.Add("Npwp", Npwp, DbType.String);
            parameters.Add("Masa", Masa, DbType.String);
            parameters.Add("Tahun", Tahun, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<Dashboard.Detail>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<Dashboard.Total> GetTotalDashboard(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyCode", CompanyCode, DbType.String);
            parameters.Add("Npwp", Npwp, DbType.String);
            parameters.Add("Masa", Masa, DbType.String);
            parameters.Add("Tahun", Tahun, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.Get<Dashboard.Total>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }
    }
}
