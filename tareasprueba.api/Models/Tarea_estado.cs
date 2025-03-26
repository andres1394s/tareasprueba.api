using System.ComponentModel.DataAnnotations;

namespace tareasprueba.api.Models
{
    public class Tarea_estado
    {
        [Key]
        public int id_estado {  get; set; }
        public string descripcion { get; set; } = string.Empty;

    }
}
