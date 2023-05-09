using apifinal.Dtos;
using apifinal.Entities;
using apifinal.Repository;
using AutoMapper;

namespace apifinal.Services
{
    public class FacturaServices : IFacturaServices
    {
        public readonly IFacturaRepository _repository;
        private readonly IMapper _mapper;

        public FacturaServices(IFacturaRepository repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }
        
        public void AgregarFactura(FacturaDTO facturaDTO)
        {
            Factura factura = _mapper.Map<Factura>(facturaDTO);

            _repository.AgregarFactura(factura);
            _repository.SaveChange();
        }

        public IEnumerable<FacturaDTO> TraerTodasFacturas()
        {
            var factura = _repository.TraerTodasFacturas();
            return _mapper.Map<IEnumerable<FacturaDTO>>(factura);
        }

        public FacturaDTO TraerFacturaPorId(int id)
        {
            Factura factura = _repository.TraerFacturaPorId(id);
            FacturaDTO facturaDTO = _mapper.Map<FacturaDTO>(factura);
            return facturaDTO;
        }

        public void BorrarFacturaPorID(int facturaId)
        {
            var facturaaencontrar = _repository.TraerFacturaPorId(facturaId);
            _repository.BorrarFacturaPorID(facturaId);
            _repository.SaveChange();
        }

        public void BorrarFacturaPorNumero(int nFactura)
        {
            _repository.BorrarFacturaPorNumero(nFactura);
            _repository.SaveChange();
        }

        public void ActualizarFactura(int id, FacturaDTO facturaDTO)
        {
            var facturaaencontrar = _repository.TraerFacturaPorId(id);
            _mapper.Map(facturaDTO, facturaaencontrar);
            _repository.ActualizarFactura(facturaaencontrar);
            _repository.SaveChange();
        }
    }
}