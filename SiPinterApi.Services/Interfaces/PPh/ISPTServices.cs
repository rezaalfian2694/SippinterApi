using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Services.PPh
{
    public interface ISPTServices
    {
        Task<List<SPT>> GetListSPT(string CompanyCode, string Npwp, string Masa, string Tahun);
        Task<ResponseEntity> InitPosting(string CompanyCode, string Npwp, string Masa, string Tahun, string Username);
        Task<ResponseEntity> Approval(int idSpt, string Comment, int isApproved, string Username);
    }
}
