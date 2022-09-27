using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;
using System.Data;

namespace SiPinterApi.Repositories.PPh
{
    public interface IUploadPembayaranRepository
    {
        Task<List<Pembayaran>> GetDataPembayaran(string CompanyCode, string Npwp, string Masa, string Tahun);
        Task<ResponseEntity> InsertDataPembayaran(DataTable data, string Username);
        Task<ResponseEntity> DeleteDataPembayaran(int ID, string Username);

    }
}
