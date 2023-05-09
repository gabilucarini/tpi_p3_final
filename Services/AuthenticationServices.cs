using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifinal.Entities;
using apifinal.Repository;
using RatingAPI.Models;

namespace apifinal.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUsuarioRepository _repository;

        public AuthenticationServices(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public Usuario ValidacionUsuario(AuthenticationRequestBody authenticationRequestBody)
        {
            if (string.IsNullOrEmpty(authenticationRequestBody.UserName) || string.IsNullOrEmpty(authenticationRequestBody.Password))
                return null;

            return _repository.ValidacionUsuario(authenticationRequestBody);
        }
    }
}