using data.context;
using domain.entidades;
using gotaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gotaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobreController : ControllerBase
    {
        private readonly Context _context;
        public SobreController(Context context)
        {
            _context = context;
        }


        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] SobreModel model)
        {
            try
            {
                var sobre = _context.Sobre.FirstOrDefault(a => a.Id == model.Id);
                if (sobre == null)
                {
                    throw new Exception("Não encontrado.");
                }
                sobre.Editar(model.Descricao);
                _context.Sobre.Update(sobre);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Editado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpGet]
        public async Task<ActionResult> Buscar()
        {
            try
            {
                return Ok(await _context.Sobre.Where(a => !a.Lixeira && !a.Arquivado).Select(a => new SobreModel()
                {
                    Id = a.Id,
                    DataDeCadastro = a.DataDeCadastro,
                    DataDeAtualizacao = a.DataDeAtualizacao,
                    Descricao = a.Descricao
                }).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
