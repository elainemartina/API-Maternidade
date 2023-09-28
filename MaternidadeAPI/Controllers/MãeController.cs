using MaternidadeAPI.DBOs;
using MaternidadeAPI.Models;
using MaternidadeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaternidadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MãeController : ControllerBase
    {
        private readonly IMãeService _service;
        public MãeController(IMãeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MãeModel>>> GetMães()
        {
            var mães = await _service.GetAllMãe();
            return Ok(mães);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<MãeModel>> GetMãeId(int Id)
        {
            var mãe = await _service.GetByIdMãe(Id);
            if (mãe == null) return NotFound($"Mãe com o ID {Id} não encontrada! Tente novamente com outro ID");
            return Ok(mãe);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMãe(DTOMãe mae)
        {
            if (mae == null) 
                return BadRequest("Dados inválidos pra criação de uma nova mãe!");
            MãeModel model = new MãeModel
            {
                Nome = mae.Nome,
                Sobrenome = mae.Sobrenome, 
                Nascimento = mae.Nascimento,
                RG = mae.RG,
                CPF = mae.CPF,
                Endereço = mae.Endereço,
                Telefone = mae.Telefone,
                EstadoCivil = mae.EstadoCivil,
                Profissão = mae.Profissão,
                Etnia = mae.Etnia,
                HistoricoMedico = mae.HistoricoMedico
            };
          
            var Id = await _service.CreateMãe(model);
            return CreatedAtAction(nameof(GetMãeId), new { Id }, Id);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<int>> UpdateMãeId(int Id, DTOMãe model) 
        {
            var mae = await _service.UpdateMãe(Id, model);

            if (Id == null)
                return BadRequest("Dados inválidos!");

            return Ok(mae);
        }

        [HttpPatch("/HistoricoMedidco/{Id}")]
        public async Task<ActionResult<int>> UpdateMãeHistoricoMedicoId(int Id, string historico)
        {
            await _service.UpdateHistoricoMedicoMae(Id, historico);
            var mãe = await _service.GetByIdMãe(Id);
            return Ok("Histórico Médico atualizado com sucesso!");
        }

        [HttpGet("/maes/estado_civil=solteira")]
        public async Task<ActionResult<List<MãeModel>>> GetMaesEstadoCivil()
        {
            var mae = await _service.GetMaeByEstadoCivil();
            if (mae == null || mae.Count == 0) 
                return NotFound("Mãe com o estado civil solteira não encontrada, tente novamente!");

            return Ok(mae);
        }

        [HttpGet("/Profissão/{profissão}")]
        public async Task<ActionResult<List<MãeModel>>> GetMãesProfissão(string profissão)
        {
            var mãe = await _service.GetMãeByProfissão(profissão);
            if (mãe == null || mãe.Count == 0) return NotFound($"Mães com a profissão {profissão} não encontradas, tente novamente!");
            return Ok(mãe);
        }


        [HttpGet("/Etnia/{etnia}")]
        public async Task<ActionResult<List<MãeModel>>> GetMaeByEtnia(string etnia)
        {
            var mae = await _service.GetMaeByEtnia(etnia);
            if (mae == null || mae.Count == 0) 
                return NotFound($"Mães com a etnia: {etnia} não encontradas, tente novamente!");

            return Ok(mae);
        }

        [HttpGet("/FilhosPorMae/{Id}")]
        public async Task<ActionResult<List<MãeModel>>> GetRNsMãe(int Id)
        {
            var filhos = await _service.GetRnsByMãeId(Id);
            if (filhos == null || filhos.Count == 0) 
                return NotFound($"Não foi encontrado filhos desta mãe, tente novamente!");
            return Ok(filhos);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<int>> DeleteMãeId(int Id)
        {
            var mãe = await _service.GetByIdMãe(Id);
            if (mãe == null) return NotFound($"Mãe com o ID {Id} não encontrada! Tente novamente com outro ID");
            await _service.DeleteMãe(Id);
            return Ok($"{mãe.Nome} {mãe.Sobrenome} deletada com sucesso da base de dados!");
        }

        [HttpGet("/Maes/{id}/Recem-Nascidos/Parto={parto}")]
        public async Task<ActionResult<List<MãeModel>>> GetRNByTipoParto(int id, string parto)
        {
            var filhos = await _service.GetRNByTipoParto(id, parto);

            if (filhos == null || filhos.Count == 0) 
                return NotFound($"Não foi encontrado filhos desta mãe deste tipo de parto, tente novamente!");

            return Ok(filhos);
        }

        // Criar RN - POST ----
        [HttpPost("RN")]
        public async Task<ActionResult<int>> CreateRn(int id, DTORN rn)
        {
            if (id == null)
                return BadRequest("Dados inválidos pra criação de uma nova mãe!");

            RNModel model = new RNModel
            {
                Nome = rn.Nome,
                Genero = rn.Genero,
                Nascimento = rn.Nascimento,
                Peso = rn.Peso,
                Altura = rn.Altura,
                Apgar = rn.Apgar,
                TipoParto = rn.TipoParto,
                CondiçãoMedica = rn.CondiçãoMedica
            };

            var Id = await _service.CreateRn(id, model);
            return CreatedAtAction(nameof(CreateRn), new { Id }, Id);
        }

        [HttpGet("/Maes/{id}/Recem-Nascidos/{genero}")]
        public async Task<ActionResult<MãeModel>> GetRnByGenero(int id, string genero)
        {
            var mae = await _service.GetRnByGenero(id, genero);
            if (mae == null) 
                return NotFound($"Mãe com o ID {id} não encontrada! Tente novamente com outro ID");

            return Ok(mae);
        }

        [HttpGet("/Maes/{id}/Recem-Nascidos/Peso_min={peso}")]
        public async Task<ActionResult<MãeModel>> GetRnByPeso(int id, double peso)
        {
            var mae = await _service.GetRnByPeso(id, peso);
            if (mae == null)
                return NotFound($"Mãe com o ID {id} não encontrada! Tente novamente com outro ID");

            return Ok(mae);
        }

    }
}
