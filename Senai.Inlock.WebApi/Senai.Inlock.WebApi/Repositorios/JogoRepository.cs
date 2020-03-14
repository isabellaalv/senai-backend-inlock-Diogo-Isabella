using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositorios
{
    public class JogoRepository : IJogoRepository
    {
        public InLockContext _context { get; set; }
        public JogoRepository()
        {

        }

        public JogoRepository(InLockContext context)
        {
            _context = context;
        }

        public Jogo Create(Jogo jogo)
        {
            var retorno = _context.Jogos.Add(jogo).Entity;
            _context.SaveChanges();
            return retorno;
        }

        public void Deletar(Jogo jogo)
        {
            _context.Jogos.Remove(jogo);
            _context.SaveChanges();
        }

        public List<Jogo> GetAll()
        {
            return _context.Jogos.ToList();
        }
        public Jogo GetById(int id)
        {
            return _context.Jogos.FirstOrDefault(x => x.Id == id);
        }
    }
}
