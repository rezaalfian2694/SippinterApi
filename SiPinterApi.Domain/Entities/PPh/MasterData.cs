using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities.PPh
{
    public class MasterData
    {
        public class Config
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string IdValue { get; set; }
            public string KeyName { get; set; }
            public string Text { get; set; }
            public string Others { get; set; }
        }

        public class Company
        {
            public string CompanyCode { get; set; }
            public string CompanyName { get; set; }
            public string Npwp { get; set; }
        }
    }
}
