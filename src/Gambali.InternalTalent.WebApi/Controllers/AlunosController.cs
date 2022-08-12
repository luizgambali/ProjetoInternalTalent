using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : Controller
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
        public async Task<ActionResult<ResponseDTO>> GetByID(int Id)
        {
            _log.LogDebug($"Recebendo requisição para obter aluno por id {Id}");

            var resposta = await _alunoService.GetOneAsync(Id);

            if (resposta.ResponseOk == false && resposta.ResultObject == null)
                return NotFound();

            return Ok(resposta);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAll()
        {
            _log.LogDebug($"Recebendo requisição para obter todos os alunos");

            var resposta = await _alunoService.GetAllAsync();

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Insert([FromBody] AlunoDTO aluno)
        {
            _log.LogDebug($"Recebendo requisição para inserir um aluno");

            var resposta = await _alunoService.InsertAsync(aluno);

            if (resposta.ResponseOk)
                return Ok(resposta);
            else
                return BadRequest(resposta);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> Update(int id, [FromBody] AlunoDTO aluno)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de um aluno");

            if (id != aluno.Id)
                return BadRequest("O id informado como parametro é diferente do id informado para o aluno");

            var resposta = await _alunoService.GetOneAsync(id);

            if (resposta.ResponseOk == false && resposta.ResultObject == null)
                return NotFound();

            var result = await _alunoService.UpdateAsync(aluno);

            if (result.ResponseOk)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> Delete(int id)
        {
            _log.LogDebug($"Recebendo requisição para atualizar dados de um aluno");

            var resposta = await _alunoService.GetOneAsync(id);

            if (resposta.ResponseOk == false && resposta.ResultObject == null)
                return NotFound();
            
            var result = await _alunoService.DeleteAsync(id);

            if (result.ResponseOk)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
