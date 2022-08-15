using Gambali.InternalTalent.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.WebApi.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult<ResponseDTO> CustomResponse(ResponseDTO? response)
        {
            if (response == null)
                return NoContent();

            if (response.ResponseOk)
            {
                return Ok(response);
            }
            else 
            {
                if (response.ErrorCode == 404)
                    return NotFound();

                return StatusCode(response.ErrorCode);
            }
        }
    }
}
