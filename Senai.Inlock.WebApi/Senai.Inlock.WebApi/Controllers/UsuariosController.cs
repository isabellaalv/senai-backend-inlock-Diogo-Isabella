using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuarioRepository _usuarioRepository { get; set; }
        public InLockContext _context { get; set; }

        public UsuariosController()
        {
            _context = new InLockContext();
            _usuarioRepository = new UsuarioRepository(_context);
        }
        /// <summary>
        /// Cadastra um usuário 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna o objeto criado</returns>
        /// <response code="201">Usuário criado</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Create (Usuario usuario)
        {
            var usuarioCriado = _usuarioRepository.Create(usuario);

            return Created("https://localhost:5000/api/Jogos", usuarioCriado);
        }
    }
}
