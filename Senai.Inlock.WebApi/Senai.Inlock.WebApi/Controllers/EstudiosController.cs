using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class EstudiosController : ControllerBase
    {
        public IEstudioRepository _estudioRepository { get; set; }
        public IJogoRepository _jogoRepository { get; set; }
        public InLockContext _context { get; set; }

        public EstudiosController()
        {
            _context = new InLockContext();
            _estudioRepository = new EstudioRepository(_context);
            _jogoRepository = new JogoRepository(_context);
        }
        /// <summary>
        /// Cadastra um estudio
        /// </summary>
        /// <param name="estudio"></param>
        /// <returns>retorna um IActionResult, com o objeto criado</returns>
        /// <response code="201">Estudio Criado</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Create (Estudio estudio)
        {
            var EstudioCriado = _estudioRepository.Create(estudio);

            return Created("https://localhost:5000/api/Jogos", EstudioCriado);
        }
        /// <summary>
        /// Lista os estudios
        /// </summary>
        /// <returns>Retorna uma lista de estudios</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var estudios = _estudioRepository.GetAll();

            var jogos = _jogoRepository.GetAll();

            var EstudiosJogos = estudios.Select(x => new
            {
                x.Id,
                x.Descricao,
                Jogos = jogos.Where(i => i.EstudioId == x.Id).Select(j => new
                {
                    j.Id,
                    j.Nome,
                    j.Valor,
                    j.Descricao,
                    j.DataLancamento
                }).ToList()
            }).ToList();

            return Ok(EstudiosJogos);
        }

        /// <summary>
        /// Deleta um estudio, NÃO USAR.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna um status code 200</returns>
        /// <response code="404"> Estudio não encongtrado.</response>
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize (Roles = "1")]
        //[HttpDelete ("{Id}")]
        //public IActionResult Deletar(int Id)
        //{
        //    var Estudios = _estudioRepository.GetById(Id);
        //    if (Estudios == null)
        //        return NotFound($"Não encontrado o estudio Id {Id}");

        //   _estudioRepository.Deletar(Estudios);

        //    return Ok($"Estudio {Estudios.Descricao} deletado");
        //}
    }
}
