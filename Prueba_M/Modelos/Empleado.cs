using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_M.Modelos
{
    public class Empleado
    {
        [Key]
        public long Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [ForeignKey("Cargo")]
        public int Id_cargo { get; set; }

        public Cargo? Cargo { get; set; }

        [ForeignKey("Salario")]
        public int Id_salario { get; set; }

        public Salario? Salario { get; set; }   
    }
}
