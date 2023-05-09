using apifinal.Entities;
using RatingAPI.Models;

namespace apifinal.Services
{
    public interface IAuthenticationServices
    {
        Usuario ValidacionUsuario(AuthenticationRequestBody authenticationRequestBody);
    }
}