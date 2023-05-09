using System.Security.Claims;
using apifinal.Dtos;
using apifinal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apifinal.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/facturacion")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServices _services;

        public FacturaController(IFacturaServices services)
        {
            _services = services;
        }
        [HttpGet]
        public ActionResult<IEnumerable<FacturaDTO>> TraerFacturas()
        {
         var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "administrator")
                return Forbid();
            var facturas = _services.TraerTodasFacturas();
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public ActionResult<FacturaDTO> TraerFacturasPorId(int id)
        {
            var facturaDTO = _services.TraerFacturaPorId(id);
            return Ok(facturaDTO);
        }

        [HttpPost]
        public ActionResult CrearFactura(FacturaDTO facturaDTO)
        {
            try
            {
                _services.AgregarFactura(facturaDTO);
                return Ok("Factura creada correctamente");
            }
            catch
            {
                return BadRequest("Error al crear factura");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult BorrarFacturaPorID(int id)
        {
            try
            {
                _services.BorrarFacturaPorID(id);
                return Ok("Factura borrada correctamente");
            }
            catch
            {
                return BadRequest("Error al borrar factura");
            }
        }

        [HttpDelete("factura/{nFactura}")]
        public ActionResult BorrarFacturaPorNumero(int nFactura)
        {
            try
            {
                _services.BorrarFacturaPorNumero(nFactura);
                return Ok("Factura borrada correctamente");
            }
            catch
            {
                return BadRequest("Error al borrar factura");
            }
        }

        [HttpPut("{id}")]
        public ActionResult ActualizarFacturaId(int id, FacturaDTO facturaDTO)
        {
            try
            {
                _services.ActualizarFactura(id,facturaDTO);
                return Ok("Factura actualizada correctamente");
            }
            catch
            {
                return BadRequest("Error al actualizar factura");
            }
        }
    }
}