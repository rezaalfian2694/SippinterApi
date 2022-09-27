using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities.PPh
{
    public class DJP_Req
    {
        public class DefaultParam
        {
            public string token { get; set; }
            public string xtoken { get; set; }
            public string baseUrl { get; set; }
            public int timeout { get; set; }
        }

        public class SSP_Add
        {
            public string fgPbkBpe { get; set; }
            public string fgSsKb { get; set; }
            public string jmlBruto { get; set; }
            public string jmlSetor { get; set; }
            public string kdJnsSetor { get; set; }
            public string kdMap { get; set; }
            public string kdObjPjk { get; set; }
            public string msPajak { get; set; }
            public string thnPajak { get; set; }
            public string noBuktiSetor { get; set; }
            public string npwp { get; set; }
            public string npwpSsp { get; set; }
            public string tglSetor { get; set; }
        }

        public class SSP_Delete
        {
            public string idSetor { get; set; }
            public string fgSsKb { get; set; }
            public string npwp { get; set; }
        }

        public class Posting
        {
            public string jnsSpt { get; set; }
            public string msPajak { get; set; }
            public string revNo { get; set; }
            public string npwp { get; set; }
            public string thnPajak { get; set; }
        }

        public class RevMax
        {
            public string jnsspt { get; set; }
            public string mspjk { get; set; }
            public string thnpjk { get; set; }
            public string npwp { get; set; }
        }

        public class KirimLengkapi
        {
            public string idSpt { get; set; }
            public string npwp { get; set; }
            public string nama { get; set; }
            public string thnPajak { get; set; }
            public string msPajak { get; set; }
            public string revNo { get; set; }
            public string fgDOSS { get; set; }
            public string jmlPphSs { get; set; }
            public string jmlBrutoSs { get; set; }
            public string jmlBruto7a { get; set; }
            public string jmlBruto7b { get; set; }
            public string jmlPph7a { get; set; }
            public string jmlPph7b { get; set; }
            public string jmlPph7c { get; set; }
            public string jmlPph7d { get; set; }
            public string jmlPph7e { get; set; }
            public List<DokDipersamakan> dokDipersamakan { get; set; }
            public string fgTtdSbg { get; set; }
            public string nikNpwpTtd { get; set; }
            public string namaTtd { get; set; }
        }

        public class DokDipersamakan
        {
            public string kdObjPjk { get; set; }
            public string jmlBruto { get; set; }
            public string jmlPph { get; set; }
            public string nmObjPjk { get; set; }
        }

        public class GetSigner
        {
            public string idSpt { get; set; }
            public string npwp { get; set; }
            public string masapjk { get; set; }
            public string thnpjk { get; set; }
            public string pathp12 { get; set; }
            public string pass { get; set; }
        }

        public class Submit
        {
            public string idSpt { get; set; }
            public string msPjk { get; set; }
            public string npwp { get; set; }
            public string serial { get; set; }
            public string tglSpt { get; set; }
            public string thnPjk { get; set; }
            public string signature { get; set; }
        }
    }
}
