using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Domain.Entities
{
    public class LogEntity
    {
        public string Action { get; set; }
        public string Page { get; set; }
        public string IPAddress { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public LogType Type { get; set; }
        public string Description { get; set; }
        public string CompanyCode { get; set; }

        public enum LogType
        {
            Error,
            Success,
            Failed
        }
    }
}
