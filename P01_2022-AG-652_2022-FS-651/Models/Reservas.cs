using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P01_2022_AG_652_2022_FS_651.Models
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int CantidadHoras { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
        [ForeignKey("EspacioParqueo")]
        public int EspacioId { get; set; }
    }
}

