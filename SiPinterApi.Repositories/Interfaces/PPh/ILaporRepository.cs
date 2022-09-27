using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Repositories.PPh
{
    public interface ILaporRepository
    {
        Task<ResponseEntity> GetRevNo(string CompanyCode, string Npwp, string Masa, string Tahun);
        Task<ResponseEntity> Posting(string CompanyCode, string Npwp, string Masa, string Tahun, string IdSpt, string Username);
        Task<ResponseEntity> Submit(int idSptHeader, string Ntte, string TglLapor, string Username);
    }
}
