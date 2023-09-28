using MaternidadeAPI.DBOs;
using MaternidadeAPI.Models;
using MaternidadeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MaternidadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RNController : ControllerBase
    {
        private readonly IRNService _service;
        public RNController(IRNService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RNModel>>> GetRNs()
        {
            var rns = await _service.GetAllRn();
            return Ok(rns);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RNModel>> GetRNId(int Id)
        {
            var rn = await _service.GetByIdRn(Id);
            if (rn == null) return NotFound($"RN com o ID {Id} não encontrada! Tente novamente com outro ID");
            return Ok(rn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateRNId(int id, DTORN rn)
        {
            var bebe = await _service.UpdateRn(rn, id);

            if (id == null)
                return BadRequest("Dados inválidos!");

            return Ok(bebe);

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<int>> DeleteRnId(int Id)
        {
            var rn = await _service.GetByIdRn(Id);
            if (rn == null) return NotFound($"RN com o ID {Id} não encontrada! Tente novamente com outro ID");
            await _service.DeleteRn(Id);
            return Ok($"{rn.Nome} deletado com sucesso da base de dados!");
        }

    }
}
