using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_M.Context;
using Prueba_M.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba_M.Controllers
{
    [Route("api/Prueba")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly Conectivity conectivity;
        public PruebaController(Conectivity conectivity) 

        {
            this.conectivity = conectivity;
        }

        // GET: api/<PruebaController>
        [HttpGet]
        public IActionResult Get()
        {
            var empleados = conectivity.Empleado
                .Include(e=>e.Salario)
                .Include(e=>e.Cargo).ToList();

            return Ok(empleados);
        }

        // GET api/<PruebaController>/5
        [HttpGet("{cedula}")]
        public IActionResult Get(long cedula)
        {
            var empleado = conectivity.Empleado
                .Include (e=>e.Salario)
                .Include (e=>e.Cargo).FirstOrDefault(e=>e.Cedula == cedula);
            return Ok(empleado);
        }

        // POST api/<PruebaController>
        [HttpPost]
        public IActionResult Post([FromBody] Empleado empleado)
        {
            conectivity.Empleado.Add(empleado);
            conectivity.SaveChanges();
            return Ok();
        }

        // PUT api/<PruebaController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Empleado empleado)
        {
            var empleado_base = conectivity.Empleado
                
                .Include(e => e.Cargo)
                .Include(e =>e.Salario).FirstOrDefault(e => e.Cedula == empleado.Cedula);

            if (empleado_base == null)
                return BadRequest();

            empleado_base.Nombre = empleado.Nombre;
            empleado_base.Apellido = empleado.Apellido;
            empleado_base.Salario.Valor = empleado.Salario.Valor;
            empleado_base.Cargo.Nombre_cargo = empleado.Cargo.Nombre_cargo;
  
            conectivity.SaveChanges();
            return Ok();
        }

        // DELETE api/<PruebaController>/5
        [HttpDelete("{cedula}")]
        public IActionResult Delete(long cedula)
        {
            var empleado_base = conectivity.Empleado
                .Include(e => e.Salario)
                .Include(e => e.Cargo).FirstOrDefault(e => e.Cedula == cedula);

            if (empleado_base == null)
                return BadRequest();

            conectivity.Empleado.Remove(empleado_base);
            conectivity.SaveChanges();
            return Ok();

        }
    }
}
