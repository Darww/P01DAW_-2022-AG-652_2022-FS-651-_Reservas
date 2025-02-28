using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P01_2022_AG_652_2022_FS_651.Models
{
    public class EspaciosParqueo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        [Required]
        public decimal CostoPorHora { get; set; }
        [Required]
        public string Estado { get; set; } // Disponible u Ocupado
        [ForeignKey("Sucursal")]
        public int SucursalId { get; set; }
    }

}
