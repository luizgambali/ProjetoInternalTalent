using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.DTO
{
    public class ResponseDTO
    {
        public bool ResponseOk { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
