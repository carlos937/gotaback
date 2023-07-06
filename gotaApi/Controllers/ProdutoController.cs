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
    public class ProdutoController : ControllerBase
    {
        private readonly Context _context;
        public ProdutoController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] ProdutoModel model)
        {
            try
            {
                var artistas = new List<Artista>();
                model.ArtistasId.ForEach(id =>
                {
                    var artista = _context.Artistas.FirstOrDefault(p => p.Id == id);
                    if (artista == null)
                    {
                        throw new Exception("Artista não encontrado.");
                    }
                    artistas.Add(artista);
                });
                _context.Produtos.Add(new Produto(model.Titulo, model.Descricao, model.Valor, artistas));
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Produto adicionado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel() { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] ProdutoModel model)
        {
            try
            {

                var artistas = new List<Artista>();
                model.ArtistasId.ForEach(id =>
                {
                    var artista = _context.Artistas.FirstOrDefault(a => a.Id == id);
                    if (artista == null)
                    {
                        throw new Exception("Artista não encontrado.");
                    }
                    artistas.Add(artista);
                });
                var produto = _context.Produtos.FirstOrDefault(p => p.Id == model.Id);
                if (produto == null)
                {
                    throw new Exception("Produto não encontrado.");
                }
                produto.Editar(model.Titulo, model.Descricao, model.Valor, artistas);
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Produto editado com sucesso." });
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
                var produto = _context.Produtos.FirstOrDefault(p => p.Id == Id);
                if (produto == null)
                {
                    throw new Exception("Produto não encontrado.");
                }
                if (arquivar) produto.Arquivar();
                else produto.Deletar();
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                var textTipo = arquivar ? "arquivado" : "deletado";
                return StatusCode(200, new ResponseModel() { mensagem = "Produto " + textTipo + " com sucesso." });
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
                return Ok(await _context.Produtos.Include(p => p.Artistas).Where(p => !p.Lixeira && !p.Arquivado).Select(p => new ProdutoModel()
                {
                    Id = p.Id,
                    DataDeCadastro = p.DataDeCadastro,
                    DataDeAtualizacao = p.DataDeAtualizacao,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    Valor = p.Valor,
                    ArtistasId = p.Artistas.Select(a => a.Id).ToList(),
                }).ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
