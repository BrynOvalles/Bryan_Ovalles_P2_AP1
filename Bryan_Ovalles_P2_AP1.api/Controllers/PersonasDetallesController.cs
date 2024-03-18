using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bryan_Ovalles_P2_AP1.api.DAL;
using Shared.Models;

namespace Bryan_Ovalles_P2_AP1.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasDetallesController : ControllerBase
    {
        private readonly Contexto _context;

        public PersonasDetallesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/PersonasDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonasDetalles>>> GetPersonasDetalles()
        {
            return await _context.PersonasDetalles.ToListAsync();
        }

        // GET: api/PersonasDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonasDetalles>> GetPersonasDetalles(int id)
        {
            var personasDetalles = await _context.PersonasDetalles.FindAsync(id);

            if (personasDetalles == null)
            {
                return NotFound();
            }

            return personasDetalles;
        }

        // POST: api/PersonasDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonasDetalles>> PostPersonasDetalles(PersonasDetalles personasDetalles)
        {
            _context.PersonasDetalles.Add(personasDetalles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonasDetalles", new { id = personasDetalles.Id }, personasDetalles);
        }

        // PUT: api/PersonasDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonasDetalles(int id, PersonasDetalles personasDetalles)
        {
            if (id != personasDetalles.Id)
            {
                return BadRequest();
            }

            _context.Entry(personasDetalles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasDetallesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PersonasDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonasDetalles(int id)
        {
            var personasDetalles = await _context.PersonasDetalles.FindAsync(id);
            if (personasDetalles == null)
            {
                return NotFound();
            }

            _context.PersonasDetalles.Remove(personasDetalles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonasDetallesExists(int id)
        {
            return _context.PersonasDetalles.Any(e => e.Id == id);
        }
    }
}
