using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities.PPh
{
    public class SPT
    {
        public int Id { get; set; }
        public string IdSpt { get; set; }
        public string CompanyCode { get; set; }
        public string Company { get; set; }
        public string Npwp { get; set; }
        public string Penandatangan { get; set; }
        public string Masa { get; set; }
        public string Tahun { get; set; }
        public string Status { get; set; }
    }

    public class SPTHeader
    {
        public string IdSpt { get; set; }
        public string Cocode { get; set; }
        public string Npwp { get; set; }
        public string MasaPajak { get; set; }
        public string TahunPajak { get; set; }
        public string Pembetulan { get; set; }
        public string Company { get; set; }
        public string CompanyName { get; set; }
        public string Nama { get; set; }
    }
}
