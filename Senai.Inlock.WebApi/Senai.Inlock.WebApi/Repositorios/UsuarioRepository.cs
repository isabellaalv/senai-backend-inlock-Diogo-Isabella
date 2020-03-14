using Senai.Inlock.WebApi.Contexts;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public InLockContext _context { get; set; }
        public UsuarioRepository()
        {

        }

        public UsuarioRepository(InLockContext context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailSenha(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
        }

        public Usuario Create(Usuario usuario)
        {
            var retorno = _context.Usuarios.Add(usuario).Entity;
            _context.SaveChanges();
            return retorno;
        }


    }
}
