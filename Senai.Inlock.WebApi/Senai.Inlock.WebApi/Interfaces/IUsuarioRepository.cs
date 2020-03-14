using Senai.Inlock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Create(Usuario usuario);
        Usuario BuscarPorEmailSenha(Usuario usuario);
    }
}
