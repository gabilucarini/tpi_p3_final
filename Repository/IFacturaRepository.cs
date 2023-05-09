using apifinal.Entities;

namespace apifinal.Repository
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> TraerTodasFacturas();
        void AgregarFactura(Factura factura);
        Factura TraerFacturaPorId(int facturaId);
        void BorrarFacturaPorID(int facturaId);
        void BorrarFacturaPorNumero(int nFactura);
        void ActualizarFactura(Factura factura);
        bool SaveChange();
    }
}