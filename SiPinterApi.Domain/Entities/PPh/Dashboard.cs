using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities.PPh
{
    public class Dashboard
    {
        public class IndexDashboard
        {
            public string CompanyCode { get; set; }
            public string CompanyName { get; set; }
            public string Company { get; set; }
            public string Npwp { get; set; }
            public string Valid { get; set; }
            public string Rejected { get; set; }
            public string OnProgress { get; set; }
            public string Dpp { get; set; }
            public string Pph { get; set; }
            public string TotalData { get; set; }
            public string TotalDpp { get; set; }
            public string TotalPPh { get; set; }
        }
        public class Detail
        {
            public string Npwp { get; set; }
            public string JenisPajak { get; set; }
            public string TotalData { get; set; }
            public string Dpp { get; set; }
            public string Pph { get; set; }
        }

        public class Total
        {
            public string TotalData { get; set; }
            public string TotalDpp { get; set; }
            public string TotalPPh { get; set; }
        }
    }
}
