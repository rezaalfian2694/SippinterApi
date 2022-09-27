using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities.PPh;
using SiPinterApi.Repositories.PPh;

namespace SiPinterApi.Services.PPh
{
    public class DashboardServices: IDashboardServices
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardServices(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<List<Dashboard.IndexDashboard>> GetIndexDashboard(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            var result = await _dashboardRepository.GetIndexDashboard(CompanyCode, Npwp, Masa, Tahun);
            return result;
        }

        public async Task<List<Dashboard.Detail>> GetDetailDashboard(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            var result = await _dashboardRepository.GetDetailDashboard(CompanyCode, Npwp, Masa, Tahun);
            return result;
        }

        public async Task<Dashboard.Total> GetTotalDashboard(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            var result = await _dashboardRepository.GetTotalDashboard(CompanyCode, Npwp, Masa, Tahun);
            return result;
        }
    }
}
