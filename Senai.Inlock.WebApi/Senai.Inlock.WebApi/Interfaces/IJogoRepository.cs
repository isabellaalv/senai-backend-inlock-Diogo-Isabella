using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    public interface IJogoRepository
    {
        Jogo Create(Jogo jogo);
        List<Jogo> GetAll();
        Jogo GetById(int id);
        void Deletar(Jogo jogo);
    }
}
