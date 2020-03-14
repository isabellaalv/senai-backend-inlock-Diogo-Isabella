using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using Senai.Inlock.WebApi.Repositorios;
using System.Linq;

namespace Senai.Inlock.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {
        public IJogoRepository _jogoRepository { get; set; }
        public IEstudioRepository _estudioRepository { get; set; }
        public InLockContext _context { get; set; }

        public JogosController()
        {
            _context = new InLockContext();
            _jogoRepository = new JogoRepository(_context);
            _estudioRepository = new EstudioRepository(_context);
        }
        /// <summary>
        /// Lista os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var retorno = _jogoRepository.GetAll();
            var estudios = _estudioRepository.GetAll();

            //Um forEach para iterar sobre cada jogo, e acrescentar um objeto EstudioVM (ViewModel)
            //retorno.ForEach((x) =>
            //{
            //    EstudioVM = estudios.FirstOrDefault(e => e.Id == x.EstudioId);
            //});

            var jogosEstudios = retorno.Select(x => new
            {
                x.Id,
                x.Nome,
                x.Descricao,
                x.DataLancamento,
                x.Valor,
                Estudio = estudios.Where(y => y.Id == x.EstudioId).Select(e => new
                {
                    e.Id,
                    e.Descricao
                }).FirstOrDefault(),
            }).ToList();
            //Created("https://localhost:5000/api/Jogos", retorno);
            return Ok(jogosEstudios);
        }
        /// <summary>
        /// Cadastra um jogo
        /// </summary>
        /// <param name="jogo"></param>
        /// <returns>Retorna o objeto criado</returns>
        /// <response code="201">Jogo criado</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize (Roles = "1")]
        [HttpPost]
        public IActionResult Create(Jogo jogo)
        {
            var jogoCriado = _jogoRepository.Create(jogo);

            return Created("https://localhost:5000/api/Jogos", jogoCriado);
        }
        /// <summary>
        /// Deletar um jogo, passando seu Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna jogo deletado</returns>
        /// <response code="404">Jogo não encongtrado.</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        [HttpDelete ("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var jogo = _jogoRepository.GetById(Id);

            if (jogo == null)
                return NotFound($"Jogo com o id {Id} não encontrado.");

            _jogoRepository.Deletar(jogo);

            return Ok($"Jogo {jogo.Nome} deletado.");
        }
    }
}
