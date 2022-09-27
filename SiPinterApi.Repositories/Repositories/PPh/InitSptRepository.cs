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
    public class InitSptRepository: BaseRepository, IInitSptRepository
    {
        public InitSptRepository(IDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<ResponseEntity> InitPosting(string CompanyCode, string Npwp, string Masa, string Tahun, string Username)
        {
            ResponseEntity resp = new ResponseEntity();
            string ConnectionStringType = "ConnectionStringSPT";
            try
            {
                var query = "";
                var parameters = new DynamicParameters();
                parameters.Add("CompanyCode", CompanyCode, DbType.String);
                parameters.Add("Npwp", Npwp, DbType.String);
                parameters.Add("Masa", Masa, DbType.String);
                parameters.Add("Tahun", Tahun, DbType.String);
                parameters.Add("Username", Username, DbType.String);

                using var connection = DbContext(ConnectionStringType);
                var result = await Task.FromResult(connection.Get<ResultEntity>(query, parameters, ConnectionStringType, commandType: CommandType.StoredProcedure));

                if (result.Status == "S")
                {
                    resp.Type = ResponseTypeEnum.Success;
                }
                else
                {
                    resp.Type = ResponseTypeEnum.Error;
                }

                resp.Message = result.Message;
            }
            catch (Exception ex)
            {
                resp.Type = ResponseTypeEnum.Error;
                resp.Message = ex.Message;
            }

            return resp;
        }

        public async Task<ResponseEntity> Approval(int idSpt, string Comment, int isApproved, DataTable dtDetail, DataTable dtTotal, string Username)
        {
            ResponseEntity resp = new ResponseEntity();
            string ConnectionStringType = "ConnectionStringSPT";
            try
            {
                var query = "";
                var parameters = new DynamicParameters();
                parameters.Add("IdSptHeader", idSpt, DbType.Int32);
                parameters.Add("Comment", Comment, DbType.String);
                parameters.Add("isApproved", isApproved, DbType.Int32);
                parameters.Add("DtDetail", dtDetail.AsTableValuedParameter("[dbo].[]"));
                parameters.Add("DtTotal", dtTotal.AsTableValuedParameter("[dbo].[]"));

                parameters.Add("Username", Username, DbType.String);

                using var connection = DbContext(ConnectionStringType);
                var result = await Task.FromResult(connection.Get<ResultEntity>(query, parameters, ConnectionStringType, commandType: CommandType.StoredProcedure));

                if (result.Status == "S")
                {
                    resp.Type = ResponseTypeEnum.Success;
                }
                else
                {
                    resp.Type = ResponseTypeEnum.Error;
                }

                resp.Message = result.Message;
            }
            catch (Exception ex)
            {
                resp.Type = ResponseTypeEnum.Error;
                resp.Message = ex.Message;
            }

            return resp;
        }

    }
}
