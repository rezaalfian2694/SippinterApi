using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Services.PPh
{
    public interface IMasterDataServices
    {
        public Task<MasterData.Config> GetValueConfigSPT(string ConfigName);
    }
}
