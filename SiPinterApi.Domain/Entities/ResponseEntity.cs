using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SiPinterApi.Domain.Entities
{
    public class ResponseEntity
    {
        public ResponseTypeEnum Type { get; set; }
        public string Message { get; set; }
    }

    public class SqlResponseEntity
    {
        public string ResponseType { get; set; }
        public string ResponseMessage { get; set; }
    }

    [Flags]
    public enum ResponseTypeEnum
    {
        [Description(null)]
        Success = 1,
        Error = 9,
        Information = 2,
        Warning = 3
    }
}
