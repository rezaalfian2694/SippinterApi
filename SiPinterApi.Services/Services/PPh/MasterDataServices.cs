using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities.PPh;
using SiPinterApi.Repositories.PPh;

namespace SiPinterApi.Services.PPh
{
    public class MasterDataServices: IMasterDataServices
    {
        private readonly IMasterDataRepository _masterDataRepository;

        public MasterDataServices(IMasterDataRepository masterDataRepository)
        {
            _masterDataRepository = masterDataRepository;
        }
        public async Task<MasterData.Config> GetValueConfigSPT(string ConfigName)
        {
            return await _masterDataRepository.GetValueConfigSPT(ConfigName);
        }
    }
}
