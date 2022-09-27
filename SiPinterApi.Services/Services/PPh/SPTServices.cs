using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;
using SiPinterApi.Repositories.PPh;
using SiPinterApi.Shared;

namespace SiPinterApi.Services.PPh
{
    public class SPTServices: ISPTServices
    {
        private readonly ISPTListRepository _listRepository;
        private readonly IInitSptRepository _initSptRepository;
        private readonly IDashboardRepository _dashboardRepository;
        private readonly ILaporRepository _laporRepository;
        private readonly IDJP_Repository _djpRepository;
        private readonly IMasterDataRepository _masterDataRepository;
        public SPTServices( ISPTListRepository sPTListRepository,
                            IInitSptRepository initSptRepository,
                            IDashboardRepository dashboardRepository,
                            ILaporRepository laporRepository,
                            IDJP_Repository djpRepository,
                            IMasterDataRepository masterDataRepository)
        {
            _listRepository = sPTListRepository;
            _initSptRepository = initSptRepository;
            _dashboardRepository = dashboardRepository;
            _laporRepository = laporRepository;
            _djpRepository = djpRepository;
            _masterDataRepository = masterDataRepository;
        }

        public async Task<List<SPT>> GetListSPT(string CompanyCode, string Npwp, string Masa, string Tahun)
        {
            var result = await _listRepository.GetListSPT(CompanyCode, Npwp, Masa, Tahun);
            return result;
        }

        public async Task<ResponseEntity> InitPosting(string CompanyCode, string Npwp, string Masa, string Tahun, string Username)
        {
            var result = await _initSptRepository.InitPosting(CompanyCode, Npwp, Masa, Tahun, Username);
            return result;
        }

        public async Task<ResponseEntity> Approval(int idSpt, string Comment, int isApproved, string Username)
        {
            ResponseEntity resp = new ResponseEntity();
            var dataSptHeader = await _listRepository.GetSptHeaderById(idSpt);
            if(dataSptHeader != null)
            {
                var detailDashboard = await _dashboardRepository.GetDetailDashboard(dataSptHeader.Cocode, dataSptHeader.Npwp, dataSptHeader.MasaPajak, dataSptHeader.TahunPajak);
                var totalDashboard = await _dashboardRepository.GetTotalDashboard(dataSptHeader.Cocode, dataSptHeader.Npwp, dataSptHeader.MasaPajak, dataSptHeader.TahunPajak);

                List<Dashboard.Detail> details = detailDashboard;

                List<Dashboard.Total> totals = new List<Dashboard.Total>();
                Dashboard.Total total = totalDashboard;

                totals.Add(total);

                var dtDetail = Shared.Common.Converter.ListToDataTable<Dashboard.Detail>(details);
                var dtTotal = Shared.Common.Converter.ListToDataTable<Dashboard.Total>(totals);

                var approval = await _initSptRepository.Approval(idSpt, Comment, isApproved, dtDetail, dtTotal, Username);

                return approval;
            }
            else
            {
                resp.Type = ResponseTypeEnum.Error;
                resp.Message = "Data Not Found";
            }

            return resp;
        }

        public async Task<ResponseEntity> Posting(string CompanyCode, string Npwp, string Masa, string Tahun, string Username)
        {
            ResponseEntity resp = new ResponseEntity();

            string token = "";
            string xtoken = "";
            string baseUrl = "";
            string timeout = "";
            string jnsSpt = "";            
            var resultToken = await _masterDataRepository.GetValueConfigSPT("token");
            var resultXToken = await _masterDataRepository.GetValueConfigSPT("xtoken");
            var resultBaseUrl = await _masterDataRepository.GetValueConfigSPT("baseUrl");
            var resultTimeOut = await _masterDataRepository.GetValueConfigSPT("timeoutAPI");
            var resultJnsSpt = await _masterDataRepository.GetValueConfigSPT("JenisSPT");

            if (resultToken != null)
            {
                token = resultToken.Value;
            }

            if (resultXToken != null)
            {
                xtoken = resultXToken.Value;
            }

            if (resultBaseUrl != null)
            {
                baseUrl = resultBaseUrl.Value;
            }

            if (resultTimeOut != null)
            {
                timeout = resultTimeOut.Value;
            }

            if (resultJnsSpt != null)
            {
                jnsSpt = resultJnsSpt.Value;
            }

            DJP_Req.DefaultParam defaultParam = new DJP_Req.DefaultParam();
            defaultParam.token = token;
            defaultParam.timeout = Convert.ToInt32(timeout);
            defaultParam.xtoken = xtoken;
            defaultParam.baseUrl = baseUrl;

            string revNo = "";
            var resultRevNo = await _laporRepository.GetRevNo(CompanyCode, Npwp, Masa, Tahun);
            if (resultRevNo != null)
            {
                revNo = resultRevNo.Message;
            }

            DJP_Req.Posting reqPosting = new DJP_Req.Posting();
            reqPosting.msPajak = Masa;
            reqPosting.thnPajak = Tahun;
            reqPosting.jnsSpt = jnsSpt;
            reqPosting.revNo = revNo;
            reqPosting.npwp = Npwp;

            var RespPosting = await _djpRepository.Posting(defaultParam, reqPosting);
            if (RespPosting != null)
            {
                if(RespPosting.code == "1")
                {
                    string IdSpt = RespPosting.data.idSpt;
                    var result = await _laporRepository.Posting(CompanyCode, Npwp, Masa, Tahun, IdSpt, Username);
                }
                else
                {
                    resp.Type = ResponseTypeEnum.Error;
                    resp.Message = RespPosting.err_msg;
                }
            }
            else
            {
                resp.Type = ResponseTypeEnum.Error;
                resp.Message = "Response is Null";
            }

            
            return resp;
        }
    }
}
