using apifinal.Dtos;

namespace apifinal.Services
{
    public interface IUsuarioServices
    {
        void AgregarUsuario(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> TraerTodosLosUsuarios();
    }
}