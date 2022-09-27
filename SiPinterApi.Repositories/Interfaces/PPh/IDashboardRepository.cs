using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Repositories.PPh
{
    public interface IDashboardRepository
    {
        Task<List<Dashboard.IndexDashboard>> GetIndexDashboard(string CompanyCode, string Npwp, string Masa, string Tahun);
        Task<List<Dashboard.Detail>> GetDetailDashboard(string CompanyCode, string Npwp, string Masa, string Tahun);
        Task<Dashboard.Total> GetTotalDashboard(string CompanyCode, string Npwp, string Masa, string Tahun);
    }
}
