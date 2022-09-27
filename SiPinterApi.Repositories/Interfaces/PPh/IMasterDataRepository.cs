using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Repositories.PPh
{
    public interface IMasterDataRepository
    {
        public Task<MasterData.Config> GetValueConfigSPT(string ConfigName);
        Task<MasterData.Config> GetValueConfigH2H(string ConfigName);
        Task<List<MasterData.Company>> GetCompanyCode();
        Task<List<MasterData.Company>> GetNpwpBasedCompany(string CompanyCode);
        Task<List<MasterData.Company>> GetNpwpBasedUser(string UserId);
    }
}
