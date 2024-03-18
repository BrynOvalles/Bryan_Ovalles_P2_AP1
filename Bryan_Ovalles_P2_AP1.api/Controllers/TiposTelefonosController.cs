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
    public class TiposTelefonosController : ControllerBase
    {
        private readonly Contexto _context;

        public TiposTelefonosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/TiposTelefonos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposTelefonos>>> GetTiposTelefonos()
        {
            return await _context.TiposTelefonos.ToListAsync();
        }

        // GET: api/TiposTelefonos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposTelefonos>> GetTiposTelefonos(int id)
        {
            var tiposTelefonos = await _context.TiposTelefonos.FindAsync(id);

            if (tiposTelefonos == null)
            {
                return NotFound();
            }

            return tiposTelefonos;
        }

        // PUT: api/TiposTelefonos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposTelefonos(int id, TiposTelefonos tiposTelefonos)
        {
            if (id != tiposTelefonos.TipoId)
            {
                return BadRequest();
            }

            _context.Entry(tiposTelefonos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposTelefonosExists(id))
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

        // POST: api/TiposTelefonos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposTelefonos>> PostTiposTelefonos(TiposTelefonos tiposTelefonos)
        {
            _context.TiposTelefonos.Add(tiposTelefonos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposTelefonos", new { id = tiposTelefonos.TipoId }, tiposTelefonos);
        }

        // DELETE: api/TiposTelefonos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposTelefonos(int id)
        {
            var tiposTelefonos = await _context.TiposTelefonos.FindAsync(id);
            if (tiposTelefonos == null)
            {
                return NotFound();
            }

            _context.TiposTelefonos.Remove(tiposTelefonos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposTelefonosExists(int id)
        {
            return _context.TiposTelefonos.Any(e => e.TipoId == id);
        }
    }
}
