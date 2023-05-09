using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apifinal.Entities
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int NumeroFactura { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string? Precio { get; set; }
    }
}