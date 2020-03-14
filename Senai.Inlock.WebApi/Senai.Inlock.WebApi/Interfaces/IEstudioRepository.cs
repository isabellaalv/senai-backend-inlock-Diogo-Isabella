using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    public interface IEstudioRepository
    {
        Estudio GetById(int id);
        List<Estudio> GetAll();
        Estudio Create(Estudio estudio);
        void Deletar(Estudio estudio);
    }
}
