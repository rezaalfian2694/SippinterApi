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
    public class UploadPembayaranRepository:BaseRepository, IUploadPembayaranRepository
    {
        public UploadPembayaranRepository(IDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<List<Pembayaran>> GetDataPembayaran(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            string ConStringType = "ConnectionStringH2H";
            var query = "";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyCode", CompanyCode, DbType.String);
            parameters.Add("Npwp", Npwp, DbType.String);
            parameters.Add("Masa", Masa, DbType.String);
            parameters.Add("Tahun", Tahun, DbType.String);

            using var connection = DbContext(ConStringType);
            var result = await Task.FromResult(connection.GetAll<Pembayaran>(query, parameters, ConStringType, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<ResponseEntity> InsertDataPembayaran(DataTable data, string Username)
        {
            ResponseEntity resp = new ResponseEntity();
            string ConnectionStringType = "ConnectionStringH2H";
            try
            {
                var query = "";
                var parameters = new DynamicParameters();
                parameters.Add("DT", data.AsTableValuedParameter("[dbo].[]"));
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

        public async Task<ResponseEntity> DeleteDataPembayaran(int ID, string Username)
        {
            ResponseEntity resp = new ResponseEntity();
            string ConnectionStringType = "ConnectionStringH2H";
            try
            {
                var query = "";
                var parameters = new DynamicParameters();
                parameters.Add("ID", ID, DbType.Int32);
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
