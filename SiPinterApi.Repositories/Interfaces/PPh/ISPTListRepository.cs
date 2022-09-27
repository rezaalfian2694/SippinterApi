using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Repositories.PPh
{
    public interface ISPTListRepository
    {
        Task<List<SPT>> GetListSPT(string CompanyCode, string Npwp, string Masa, string Tahun);
        Task<SPTHeader> GetSptHeaderById(int id);
    }
}
