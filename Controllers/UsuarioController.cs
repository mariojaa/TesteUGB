using Microsoft.AspNetCore.Mvc;
using TesteUGB.Models;
using TesteUGB.Repositorio;
using System;
using System.Collections.Generic;

namespace TesteUGB.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepositorio)
        {
            _usuarioRepository = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.Buscar();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _usuarioRepository.Insert(usuario);
                    return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioModel usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                await _usuarioRepository.EditarUsuario(usuario);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                await _usuarioRepository.Remove(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ops, sem conexão com o banco de dados! Aguarde alguns minutos e tente novamente.");
            }
        }
    }
}
