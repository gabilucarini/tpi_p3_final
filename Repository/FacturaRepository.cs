using apifinal.DBContext;
using apifinal.Entities;

namespace apifinal.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FacturacionContext _context;

        public FacturaRepository(FacturacionContext context)
        {
            _context = context; 
        }

        public IEnumerable<Factura> TraerTodasFacturas()
        {
            return _context.Facturas.ToList();
        }

        public void AgregarFactura(Factura factura)
        {
            _context.Add(factura);
        }

        public void BorrarFacturaPorID(int facturaId)
        {
            var factura = _context.Facturas.Find(facturaId);
            if (factura != null)
                _context.Facturas.Remove(factura);
        }

        public void BorrarFacturaPorNumero(int nFactura)
        {
            var factura = _context.Facturas.FirstOrDefault(f => f.NumeroFactura == nFactura);
            if (factura != null)
                _context.Facturas.Remove(factura);
        }

        public void ActualizarFactura(Factura factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChanges();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Factura TraerFacturaPorId(int facturaId){
            var factura = _context.Facturas.Find(facturaId);
            return factura;
        }
    }
}