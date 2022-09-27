using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiPinterApi.Services.PPh;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MDataApi : ControllerBase
    {
        private readonly IMasterDataServices _masterDataServices;
        public MDataApi(IMasterDataServices masterDataServices)
        {
            _masterDataServices = masterDataServices;
        }

        [HttpGet(Name = "GetConfigSPT")]
        public async Task<MasterData.Config> GetConfigSPT(string configName)
        {
            var result = await _masterDataServices.GetValueConfigSPT(configName);
            return result;
        }
    }
}
