using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Repositories.PPh
{
    public interface IInitSptRepository
    {
        Task<ResponseEntity> InitPosting(string CompanyCode, string Npwp, string Masa, string Tahun, string Username);
        Task<ResponseEntity> Approval(int idSpt, string Comment, int isApproved, DataTable dtDetail, DataTable dtTotal, string Username);
    }
}
