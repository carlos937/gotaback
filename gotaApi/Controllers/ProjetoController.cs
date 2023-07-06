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
    public class ProjetoController : ControllerBase
    {
        private readonly Context _context;
        public ProjetoController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] ProjetoModel model)
        {
            try
            {
                var projeto = new Projeto(model.Nome, model.Descricao);
                model.ArtistasId.ForEach(id => {
                    var artista = _context.Artistas.FirstOrDefault(a => a.Id == id);
                    if (artista == null)
                    {
                        throw new Exception("Artista não encontrado.");
                    }
                    projeto.IncluirArtista(artista);
                });
                _context.Projetos.Add(projeto);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Projeto adicionado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel() { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] ProjetoModel model)
        {
            try
            {
                var projeto = _context.Projetos.FirstOrDefault(a => a.Id == model.Id);
                if (projeto == null)
                {
                    throw new Exception("Projeto não encontrado.");
                }
                projeto.Editar(model.Nome, model.Descricao);
                projeto.LimparArtistas();
                model.ArtistasId.ForEach(id => {
                    var artista = _context.Artistas.FirstOrDefault(a => a.Id == id);
                    if (artista == null)
                    {
                        throw new Exception("Artista não encontrado.");
                    }
                    projeto.IncluirArtista(artista);
                    });
                _context.Projetos.Update(projeto);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Projeto editado com sucesso." });
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
                var projeto = _context.Projetos.FirstOrDefault(a => a.Id == Id);
                if (projeto == null)
                {
                    throw new Exception("Projeto não encontrado.");
                } 
                if(arquivar) projeto.Arquivar();
                else projeto.Deletar();
                _context.Projetos.Update(projeto);
                await _context.SaveChangesAsync();
                var textTipo = arquivar ? "arquivado" : "deletado";
                return StatusCode(200, new ResponseModel() { mensagem = "Projeto "+ textTipo +" com sucesso." });
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
                return Ok(await _context.Projetos.Where(a => !a.Lixeira && !a.Arquivado).Include(p => p.Artistas)
                    .Select(p => new ProjetoModel
                    {
                         Id = p.Id,
                         Nome = p.Nome, 
                         ArtistasId = p.Artistas != null ? p.Artistas.Select(p => p.Id).ToList(): new List<string>(),
                         DataDeAtualizacao = p.DataDeAtualizacao,
                         DataDeCadastro = p.DataDeCadastro,
                         Descricao = p.Descricao 
                    })
                    .ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
