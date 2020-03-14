using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUsuarioRepository _usuarioRepository { get; set; }
        public InLockContext _context;

        public LoginController()
        {
            _context = new InLockContext();
            _usuarioRepository = new UsuarioRepository(_context);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna Token do usuário</returns>
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var retorno = _usuarioRepository.BuscarPorEmailSenha(usuario);

            if (retorno == null)
                return NotFound("Nome e/ou senha inválidos.");
            
            var informacoesUsuario = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, retorno.Email),
                new Claim(JwtRegisteredClaimNames.Jti, retorno.Id.ToString()), // Jti claimName para ID's
                new Claim(ClaimTypes.Role, retorno.TipoUsuarioId.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senai.InLock.WebApi",         // emissor do token
                audience: "Senai.InLock.WebApi",       // destinatário do token
                claims: informacoesUsuario,             // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
