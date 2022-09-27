using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities.PPh
{
    public class DJP_Resp
    {
        public class ExceptionResp
        {
            public string? timestamp { get; set; }
            public string? status { get; set; }
            public string? error { get; set; }
            public string? message { get; set; }
            public string? path { get; set; }
        }

        public class SSP_Add
        {
            public string status { get; set; }
            public string code { get; set; }
            public RespIdSetor data { get; set; }
            public string err_msg { get; set; }
            public string dateAndTime { get; set; }
        }
        public class RespIdSetor
        {
            public string idSetor { get; set; }
        }

        public class SSP_Delete
        {
            public string status { get; set; }
            public string code { get; set; }
            public string data { get; set; }
            public string err_msg { get; set; }
            public string dateAndTime { get; set; }
        }

        public class Posting
        {
            public string? status { get; set; }
            public string? code { get; set; }
            public RespIdSpt? data { get; set; }
            public string? err_msg { get; set; }
            public string? dateAndTime { get; set; }
        }
        public class RespIdSpt
        {
            public string? idSpt { get; set; }
        }

        public class Submit
        {
            public string status { get; set; }
            public string code { get; set; }
            public DataSubmit data { get; set; }
            public string err_msg { get; set; }
            public string dateAndTime { get; set; }
        }

        public class DataSubmit
        {
            public string ntte { get; set; }
            public string fgLbkbn { get; set; }
        }

        public class RevMax
        {
            public string status { get; set; }
            public string code { get; set; }
            public DataRevMax data { get; set; }
            public string err_msg { get; set; }
            public string dateAndTime { get; set; }
        }

        public class DataRevMax
        {
            public string idSpt { get; set; }
            public string revNo { get; set; }
        }

        public class KirimLengkapi
        {
            public string status { get; set; }
            public string code { get; set; }
            public string data { get; set; }
            public string err_msg { get; set; }
            public string dateAndTime { get; set; }
        }

        public class GetKirimLengkapi
        {
            public string status { get; set; }
            public string code { get; set; }
            public DetailKirimLengkapi data { get; set; }
            public string err_msg { get; set; }
            public string dateAndTime { get; set; }
        }

        public class DetailKirimLengkapi
        {
            public string idSpt { get;set; }
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
            public string namaTtd { get;set; }
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
            public string KdStatus { get; set; }
            public string Message { get; set; }
            public string signature { get; set; }
            public string serial { get; set; }
        }

        public class QRCode
        {
            public string Ken { get; set; }
            public string Mel { get; set; }
            public string url { get; set; }
            public string MixCode { get; set; }
        }
    }
}
