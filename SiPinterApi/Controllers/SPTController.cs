using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiPinterApi.Services.PPh;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SPTController : ControllerBase
    {
        private readonly ISPTServices _SptServices;
        public SPTController(ISPTServices sPTServices)
        {
            _SptServices = sPTServices;
        }

        [HttpGet]
        public async Task<List<SPT>> GetListSpt(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            var result = await _SptServices.GetListSPT(CompanyCode, Npwp, Masa, Tahun);
            return result;
        }
    }
}
