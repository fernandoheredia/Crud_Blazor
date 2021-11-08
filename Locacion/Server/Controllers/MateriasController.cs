using Locacion.Comunes.Data;
using Locacion.Comunes.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locacion.Server.Controllers
{
    [ApiController]
    [Route("api/materias")]
    public class MateriasController : ControllerBase
    {
        private readonly dbContext context;

        public MateriasController(dbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<materia>>> Get()
        {
            //return await context.Paises.Include(x => x.Provincias).ToListAsync();
            return await context.Materias.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<materia>> Get(int id)
        {
            var materia = await context.Materias.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (materia == null)
            {
                return NotFound($"No existe la materia con id igual a {id}.");
            }
            return materia;
        }

        [HttpPost]
        public async Task<ActionResult<materia>> Post(materia materia)
        {
            try
            {
                context.Materias.Add(materia);
                await context.SaveChangesAsync();
                return materia;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var pablito = await context.Materias.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pablito == null)
            {
                return NotFound("no existe la materia a modificar.");
            }
            pablito.CodMateria = materia.CodMateria;
            pablito.NombreMateria = materia.NombreMateria;
            try
            {
                context.Materias.Update(pablito);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var materia = await context.Materias.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (materia == null)
            {
                return NotFound($"No existe la Materia con id igual a {id}.");
            }

            try
            {
                context.Materias.Remove(materia);
                await context.SaveChangesAsync();
                return Ok($"La materia {materia.NombreMateria} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}