using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.DTO
{
    public class ResponseDTO
    {
        public bool ResponseOk { get; }
        public string Message { get;  }
        public Object ResultObject { get;  }
        public int ErrorCode { get;  }

        public ResponseDTO(bool ok, string message, Object resultObject = null, int errorCode = 0 )
        {
            ResponseOk = ok;
            Message = message;
            ResultObject = resultObject;
            ErrorCode = errorCode;
        }
    }
}
