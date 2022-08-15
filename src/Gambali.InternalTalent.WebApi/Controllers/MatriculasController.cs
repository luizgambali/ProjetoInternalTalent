using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculasController : BaseController
    {
        private readonly IMatriculaService _matriculaService;
        private readonly ILogger<MatriculasController> _log;

        public MatriculasController(IMatriculaService matriculaService,
                               ILogger<MatriculasController> log)
        {
            _matriculaService = matriculaService;
            _log = log;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> GetByID(int id)
        {
            _log.LogDebug($"Recebendo requisição para obter matricula por id {id}");

            var resposta = await _matriculaService.GetOneAsync(id);

            return CustomResponse(resposta);

        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll()
        {
            _log.LogDebug($"Recebendo requisição para obter todas as matriculas");

            var resposta = await _matriculaService.GetAllAsync();

            return CustomResponse(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Insert([FromBody] MatriculaDTO matricula)
        {
            _log.LogDebug($"Recebendo requisição para inserir uma matricula");

            var resposta = await _matriculaService.InsertAsync(matricula);

            return CustomResponse(resposta);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> Update(int id, [FromBody] MatriculaDTO matricula)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de uma matricula");

            if (id != matricula.Id)
                return BadRequest("O id informado como parametro é diferente do id informado para a matricula");

            var resposta = await _matriculaService.GetOneAsync(id);

            return CustomResponse(resposta);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> Delete(int id)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de uma matricula");

            var resposta = await _matriculaService.GetOneAsync(id);

            return CustomResponse(resposta);
        }
    }
}
