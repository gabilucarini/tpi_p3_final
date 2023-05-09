using apifinal.Dtos;
using apifinal.Entities;
using apifinal.Repository;
using AutoMapper;

namespace apifinal.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioServices(IUsuarioRepository repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        

        public void AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuarioNuevo = _mapper.Map<Usuario>(usuarioDTO);

            _repository.AgregarUsuario(usuarioNuevo);
            _repository.SaveChange();
        }
    }
}