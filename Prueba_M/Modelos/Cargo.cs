using System.ComponentModel.DataAnnotations;

namespace Prueba_M.Modelos
{
    public class Cargo
    {
        [Key]
        public int Id_cargo { get; set; }
        public string Nombre_cargo { get; set; }
    }
}
