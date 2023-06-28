﻿
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

                _context.artistas.Add(new Artista(model.Nome, model.Celular, model.Atuacao));
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
                var artista = _context.artistas.FirstOrDefault(a => a.Id == model.Id);
                if (artista == null)
                {
                    throw new Exception("Artista não encontrado.");
                }
                artista.Editar(model.Nome, model.Celular, model.Atuacao);
                _context.artistas.Update(artista);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Artista editado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Deletar([FromQuery] string Id)
        {
            try
            {
                var artista = _context.artistas.FirstOrDefault(a => a.Id == Id);
                if (artista == null)
                {
                    throw new Exception("Artista não encontrado.");
                }
                _context.artistas.Remove(artista);
                await _context.SaveChangesAsync();
                return StatusCode(200, new ResponseModel() { mensagem = "Artista deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<ActionResult> Buscar()
        {
            try
            {
                return Ok( await _context.artistas.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}