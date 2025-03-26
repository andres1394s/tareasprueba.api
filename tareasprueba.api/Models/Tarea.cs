using System.ComponentModel.DataAnnotations;

namespace tareasprueba.api.Models
{
    public class Tarea
    {
        [Key]
        public int id { get; set; }
        public string nombre_tarea { get; set; } = string.Empty;
        public string estado { get; set; }
        public int id_estado { get; set; }
        public string fecha_creacion { get; set; } = string.Empty;

    }
}
