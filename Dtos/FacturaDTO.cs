using System.ComponentModel.DataAnnotations;

namespace apifinal.Dtos
{
    public class FacturaDTO
    {
    
    [Required(ErrorMessage = "El número de factura es obligatorio.")]
    public int NumeroFactura { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    public decimal Precio { get; set; }
    }
}