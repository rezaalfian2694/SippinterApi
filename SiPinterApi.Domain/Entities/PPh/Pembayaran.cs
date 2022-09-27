using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities.PPh
{
    public class Pembayaran
    {
        public int ID { get; set; }
        public string NPWP { get; set; }
        public string NOSETORAN { get; set;}
        public string KOP { get; set;}
        public string KJS { get; set;}
        public string MAP { get; set;}
        public string DPP { get; set;}
        public string PPh { get; set;}
    }
}
