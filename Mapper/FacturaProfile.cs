using AutoMapper;

namespace apifinal.Mapper
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile() {
            CreateMap<Entities.Factura, Dtos.FacturaDTO>();
            CreateMap<Dtos.FacturaDTO, Entities.Factura>();
            CreateMap<Entities.Usuario, Dtos.UsuarioDTO>();
            CreateMap<Dtos.UsuarioDTO, Entities.Usuario>();
        }
    }
}