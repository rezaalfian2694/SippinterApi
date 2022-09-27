using Dapper;
using SiPinterApi.Domain;
using SiPinterApi.Domain.Entities;
using SiPinterApi.Domain.Entities.PPh;
using SiPinterApi.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SiPinterApi.Repositories.PPh
{
    public class DJP_Repository : BaseRepository, IDJP_Repository
    {
        public DJP_Repository(IDbContext dbContext)
           : base(dbContext)
        { }

        public async Task<DJP_Resp.SSP_Add> AddSSP(DJP_Req.DefaultParam defaultParam, DJP_Req.SSP_Add param)
        {
            DJP_Resp.SSP_Add resp = new DJP_Resp.SSP_Add();
            try
            {
                JsonSerializerSettings setting = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                string json = JsonConvert.SerializeObject(param, Formatting.Indented, setting);
                string CompleteUrl = defaultParam.baseUrl + "bupot/ssp/add";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.SSP_Add>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.SSP_Delete> DeleteSSP(DJP_Req.DefaultParam defaultParam, DJP_Req.SSP_Delete param)
        {
            DJP_Resp.SSP_Delete resp = new DJP_Resp.SSP_Delete();
            try
            {

                string CompleteUrl = defaultParam.baseUrl + "bupot/ssp/delete";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);

                    var contentList = new List<string>();
                    contentList.Add($"fgSsKb={Uri.EscapeDataString(param.fgSsKb)}");
                    contentList.Add($"idSetor={Uri.EscapeDataString(param.idSetor)}");
                    contentList.Add($"npwp={Uri.EscapeDataString(param.npwp)}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.SSP_Delete>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.RevMax> RevMax(DJP_Req.DefaultParam defaultParam, DJP_Req.RevMax param)
        {
            DJP_Resp.RevMax resp = new DJP_Resp.RevMax();
            try
            {

                string CompleteUrl = defaultParam.baseUrl + "bupot/spt/revmax";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);

                    var contentList = new List<string>();
                    contentList.Add($"jnsspt={Uri.EscapeDataString(param.jnsspt)}");
                    contentList.Add($"mspjk={Uri.EscapeDataString(param.mspjk)}");
                    contentList.Add($"thnpjk={Uri.EscapeDataString(param.thnpjk)}");
                    contentList.Add($"npwp={Uri.EscapeDataString(param.npwp)}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.RevMax>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.Posting> Posting(DJP_Req.DefaultParam defaultParam, DJP_Req.Posting param)
        {
            DJP_Resp.Posting resp = new DJP_Resp.Posting();
            try
            {
                JsonSerializerSettings setting = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                string json = JsonConvert.SerializeObject(param, Formatting.Indented, setting);
                string CompleteUrl = defaultParam.baseUrl + "bupot/spt/posting";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.Posting>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }


                }

                #region Way 2

                //using (var client = new HttpClient())
                //{
                //    client.Timeout = TimeSpan.FromMilliseconds(timeout);
                //    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                //    var res = client.PostAsync(CompleteUrl, stringContent).Result;

                //    if(res.Content != null)
                //    {
                //        string respContent = res.Content.ReadAsStringAsync().Result;
                //        resp = JsonConvert.DeserializeObject<DJP_Resp.Posting>(respContent);
                //    }
                //    else
                //    {
                //        resp.code = "0";
                //        resp.err_msg = "Resp is Null";
                //    }

                //}
                #endregion

            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.GetKirimLengkapi> GetKirimLengkapi(DJP_Req.DefaultParam defaultParam, string idSpt, string npwp)
        {
            DJP_Resp.GetKirimLengkapi resp = new DJP_Resp.GetKirimLengkapi();
            try
            {

                string CompleteUrl = defaultParam.baseUrl + "bupot/spt/getlengkapispt";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);

                    var contentList = new List<string>();
                    contentList.Add($"idspt={Uri.EscapeDataString(idSpt)}");
                    contentList.Add($"npwp={Uri.EscapeDataString(npwp)}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.GetKirimLengkapi>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.KirimLengkapi> KirimLengkapi(DJP_Req.DefaultParam defaultParam, DJP_Req.KirimLengkapi param)
        {
            DJP_Resp.KirimLengkapi resp = new DJP_Resp.KirimLengkapi();
            try
            {
                JsonSerializerSettings setting = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                string json = JsonConvert.SerializeObject(param, Formatting.Indented, setting);
                string CompleteUrl = defaultParam.baseUrl + "bupot/spt/kirimlengkapispt";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.KirimLengkapi>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.GetSigner> GetSignerSPT(DJP_Req.DefaultParam defaultParam, DJP_Req.GetSigner param)
        {
            DJP_Resp.GetSigner resp = new DJP_Resp.GetSigner();
            try
            {

                string CompleteUrl = defaultParam.baseUrl + "bupot/spt/signature";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);

                    var contentList = new List<string>();
                    contentList.Add($"idspt={Uri.EscapeDataString(param.idSpt)}");
                    contentList.Add($"npwp={Uri.EscapeDataString(param.npwp)}");
                    contentList.Add($"masapjk={Uri.EscapeDataString(param.masapjk)}");
                    contentList.Add($"thnpjk={Uri.EscapeDataString(param.thnpjk)}");
                    contentList.Add($"pathp12={Uri.EscapeDataString(param.pathp12)}");
                    contentList.Add($"pass={Uri.EscapeDataString(param.pass)}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.GetSigner>(respContent);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);

                                    return null;
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return resp;
        }

        public async Task<DJP_Resp.Submit> Submit(DJP_Req.DefaultParam defaultParam, DJP_Req.Submit param)
        {
            DJP_Resp.Submit resp = new DJP_Resp.Submit();
            try
            {
                JsonSerializerSettings setting = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                string json = JsonConvert.SerializeObject(param, Formatting.Indented, setting);
                string CompleteUrl = defaultParam.baseUrl + "bupot/spt/submitspt";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.Submit>(respContent);
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    resp.code = "0";
                                    resp.err_msg = excResp.message;
                                }
                            }
                        }
                        else
                        {
                            resp.code = "0";
                            resp.err_msg = "Response is Null";
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                resp.code = "0";
                resp.err_msg = ex.Message;
            }
            return resp;
        }

        public async Task<DJP_Resp.QRCode> GetQRCodeSPT(DJP_Req.DefaultParam defaultParam, string idSpt, string npwp)
        {
            DJP_Resp.QRCode resp = new DJP_Resp.QRCode();
            try
            {

                string CompleteUrl = defaultParam.baseUrl + "bupot/bp/getqr";

                HttpClient httpClient = new HttpClient();
                using (var request = new HttpRequestMessage(HttpMethod.Post, CompleteUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", defaultParam.token);
                    request.Headers.Add("x-token", defaultParam.xtoken);

                    var contentList = new List<string>();
                    contentList.Add($"idspt={Uri.EscapeDataString(idSpt)}");
                    contentList.Add($"npwp={Uri.EscapeDataString(npwp)}");
                    contentList.Add($"tipe={Uri.EscapeDataString("BPE")}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    httpClient.Timeout = TimeSpan.FromMilliseconds(defaultParam.timeout);

                    try
                    {
                        var response = await httpClient.SendAsync(request);

                        if (response.Content != null)
                        {
                            string respContent = response.Content.ReadAsStringAsync().Result;
                            resp = JsonConvert.DeserializeObject<DJP_Resp.QRCode>(respContent);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (WebException er)
                    {
                        if (er.Response != null)
                        {
                            using (WebResponse response = (WebResponse)er.Response)
                            {
                                var httpResponse = (HttpWebResponse)response;
                                using (Stream dataStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(dataStream);
                                    string respContent = reader.ReadToEnd();

                                    DJP_Resp.ExceptionResp excResp = JsonConvert.DeserializeObject<DJP_Resp.ExceptionResp>(respContent);
                                    return null;
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return resp;
        }
    }
}
