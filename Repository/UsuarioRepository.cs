using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifinal.DBContext;
using apifinal.Entities;
using RatingAPI.Models;

namespace apifinal.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FacturacionContext _context;

        public UsuarioRepository(FacturacionContext context)
        {
            _context = context; 
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Usuario> TraerTodosLosUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? ValidacionUsuario(AuthenticationRequestBody authRequestBody)
        {
            return _context.Usuarios.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }
    }
}