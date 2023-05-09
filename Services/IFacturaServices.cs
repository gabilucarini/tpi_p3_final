using apifinal.Dtos;

namespace apifinal.Services
{
    public interface IFacturaServices
    {
        void AgregarFactura(FacturaDTO facturaDTO);
        IEnumerable<FacturaDTO> TraerTodasFacturas();
        void BorrarFacturaPorID(int facturaId);
        void BorrarFacturaPorNumero(int nFactura);
        void ActualizarFactura(int id,FacturaDTO facturaDTO);
        FacturaDTO TraerFacturaPorId(int id);
    }
}