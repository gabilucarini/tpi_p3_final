using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifinal.Entities;
using RatingAPI.Models;

namespace apifinal.Repository
{
    public interface IUsuarioRepository
    {
        void AgregarUsuario(Usuario usuario);
        public Usuario? ValidacionUsuario(AuthenticationRequestBody authRequestBody);
        bool SaveChange();
    }
}