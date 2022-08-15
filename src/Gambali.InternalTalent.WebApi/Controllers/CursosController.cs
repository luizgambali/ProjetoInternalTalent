using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : BaseController
    {
        private readonly ICursoService _cursoService;
        private readonly ILogger<CursosController> _log;

        public CursosController(ICursoService cursoService,
                               ILogger<CursosController> log)
        {
            _cursoService = cursoService;
            _log = log;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> GetByID(int id)
        {
            _log.LogDebug($"Recebendo requisição para obter curso por id {id}");

            var resposta = await _cursoService.GetOneAsync(id);

            return CustomResponse(resposta);

        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll()
        {
            _log.LogDebug($"Recebendo requisição para obter todos os cursos");

            var resposta = await _cursoService.GetAllAsync();

            return CustomResponse(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Insert([FromBody] CursoDTO curso)
        {
            _log.LogDebug($"Recebendo requisição para inserir um curso");

            var resposta = await _cursoService.InsertAsync(curso);

            return CustomResponse(resposta);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> Update(int id, [FromBody] CursoDTO curso)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de um curso");

            if (id != curso.Id)
                return BadRequest("O id informado como parametro é diferente do id informado para o curso");

            var resposta = await _cursoService.GetOneAsync(id);

            return CustomResponse(resposta);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> Delete(int id)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de um curso");

            var resposta = await _cursoService.GetOneAsync(id);

            return CustomResponse(resposta);
        }
    }
}
