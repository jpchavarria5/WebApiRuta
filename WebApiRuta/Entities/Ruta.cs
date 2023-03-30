using System.ComponentModel.DataAnnotations;

namespace WebApiRuta.Entities
{
    public class Ruta
    {
        public int Id { get; set; }
        [Required]
        public string nombreRuta { get; set; }
        public float Distancia { get; set; }
        public float Tiempo { get; set; }
    }
}
