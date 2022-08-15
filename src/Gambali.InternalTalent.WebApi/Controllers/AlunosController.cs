using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : BaseController
    {
        private readonly IAlunoService _alunoService;
        private readonly ILogger<AlunosController> _log;

        public AlunosController(IAlunoService alunoService,
                               ILogger<AlunosController> log)
        {
            _alunoService = alunoService;
            _log = log;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> GetByID(int id)
        {
            _log.LogDebug($"Recebendo requisição para obter aluno por id {id}");

            var resposta = await _alunoService.GetOneAsync(id);

            return CustomResponse(resposta);

        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll()
        {
            _log.LogDebug($"Recebendo requisição para obter todos os alunos");

            var resposta = await _alunoService.GetAllAsync();

            return CustomResponse(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Insert([FromBody] AlunoDTO aluno)
        {
            _log.LogDebug($"Recebendo requisição para inserir um aluno");

            var resposta = await _alunoService.InsertAsync(aluno);

            return CustomResponse(resposta);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> Update(int id, [FromBody] AlunoDTO aluno)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de um aluno");

            if (id != aluno.Id)
                return BadRequest("O id informado como parametro é diferente do id informado para o aluno");

            var resposta = await _alunoService.GetOneAsync(id);

            return CustomResponse(resposta);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> Delete(int id)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de um aluno");

            var resposta = await _alunoService.GetOneAsync(id);

            return CustomResponse(resposta);
        }
    }
}
