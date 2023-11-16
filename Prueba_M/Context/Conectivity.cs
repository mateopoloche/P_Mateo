using Microsoft.EntityFrameworkCore;
using Prueba_M.Modelos;

namespace Prueba_M.Context
{
    public class Conectivity:DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        public DbSet<Salario> Salario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-77701M3; Initial Catalog = PRUEBA; Persist security info = true; Integrated Security = true; Trust Server Certificate = true; multipleactiveresultsets = true; application name = EntityFramework providerName = System.Data.SqlClient");
        }
    }
}
