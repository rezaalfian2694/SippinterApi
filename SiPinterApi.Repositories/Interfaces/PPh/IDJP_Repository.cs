using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;

namespace SiPinterApi.Repositories.PPh
{
    public interface IDJP_Repository
    {
        Task<DJP_Resp.SSP_Add> AddSSP(DJP_Req.DefaultParam defaultParam, DJP_Req.SSP_Add param);
        Task<DJP_Resp.SSP_Delete> DeleteSSP(DJP_Req.DefaultParam defaultParam, DJP_Req.SSP_Delete param);
        Task<DJP_Resp.RevMax> RevMax(DJP_Req.DefaultParam defaultParam, DJP_Req.RevMax param);
        Task<DJP_Resp.Posting> Posting(DJP_Req.DefaultParam defaultParam, DJP_Req.Posting param);
        Task<DJP_Resp.GetKirimLengkapi> GetKirimLengkapi(DJP_Req.DefaultParam defaultParam, string idSpt, string npwp);
        Task<DJP_Resp.KirimLengkapi> KirimLengkapi(DJP_Req.DefaultParam defaultParam, DJP_Req.KirimLengkapi param);
        Task<DJP_Resp.GetSigner> GetSignerSPT(DJP_Req.DefaultParam defaultParam, DJP_Req.GetSigner param);
        Task<DJP_Resp.Submit> Submit(DJP_Req.DefaultParam defaultParam, DJP_Req.Submit param);
        Task<DJP_Resp.QRCode> GetQRCodeSPT(DJP_Req.DefaultParam defaultParam, string idSpt, string npwp);
    }
}
