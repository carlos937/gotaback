
using data.context;
using domain.entidades;
using gotaApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gotaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private readonly Context _context;
        public ArtistaController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] ArtistaModel model)
        {
            try
            {

                _context.Artistas.Add(new Artista(model.Nome, model.Celular, model.Atuacao));
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel(){ mensagem = "Artista adicionado com sucesso." } );
            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseModel() { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] ArtistaModel model)
        {
            try
            {
                var artista = _context.Artistas.FirstOrDefault(a => a.Id == model.Id);
                if (artista == null)
                {
                    throw new Exception("Artista não encontrado.");
                }
                artista.Editar(model.Nome, model.Celular, model.Atuacao);
                _context.Artistas.Update(artista);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Artista editado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Deletar([FromQuery] string Id, bool arquivar)
        {
            try
            {
                var artista = _context.Artistas.FirstOrDefault(a => a.Id == Id);
                if (artista == null)
                {
                    throw new Exception("Artista não encontrado.");
                } 
                if (arquivar) artista.Arquivar();
                else artista.Deletar();
                _context.Artistas.Update(artista);
                await _context.SaveChangesAsync();
                var textTipo = arquivar ? "arquivado" : "deletado";
                return StatusCode(200, new ResponseModel() { mensagem = "Artista " + textTipo + " com sucesso." });
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
                return Ok( await _context.Artistas.Where(a => !a.Lixeira && !a.Arquivado).Select(a => new ArtistaModel()
                {
                     Id = a.Id,
                     DataDeCadastro = a.DataDeCadastro,
                     DataDeAtualizacao = a.DataDeAtualizacao,
                     Atuacao  = a.Atuacao,
                     Celular = a.Celular,
                     Nome = a.Nome
                }).ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
