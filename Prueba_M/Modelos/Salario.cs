using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Prueba_M.Modelos
{
    public class Salario
    {
        [Key]
        public int Id_Salario { get; set; }
        public long Valor { get; set; }
    }
}
