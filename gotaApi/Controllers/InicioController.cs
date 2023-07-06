using data.context;
using gotaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gotaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        private readonly Context _context;
        public InicioController(Context context)
        {
            _context = context;
        }


        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] ContatoModel model)
        {
            try
            {
                var contato = _context.Contato.FirstOrDefault(c => c.Id == model.Id);
                if (contato == null)
                {
                    throw new Exception("Não encontrado.");
                }
                contato.Editar(contato.Endereco, contato.LinkInstagram, contato.LinkWhatsapp, contato.LinkYoutube);
                _context.Contato.Update(contato);
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
                return Ok(await _context.Contato.Where(c => !c.Lixeira && !c.Arquivado).Select(c => new ContatoModel()
                {
                    Id = c.Id,
                    DataDeCadastro = c.DataDeCadastro,
                    DataDeAtualizacao = c.DataDeAtualizacao,
                    Endereco = c.Endereco,
                    LinkInstagram = c.LinkInstagram,
                    LinkWhatsapp = c.LinkWhatsapp,
                    LinkYoutube = c.LinkYoutube
                }).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
