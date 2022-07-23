using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste_lista.Data;
using teste_lista.Models;

namespace teste_lista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        private readonly DbList _context;

        public ListaController(DbList context)
        {
            _context = context;
        }

        // GET: api/Lista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lista>>> GetLista()
        {
          if (_context.Lista == null)
          {
              return NotFound();
          }
            return await _context.Lista.ToListAsync();
        }

        // GET: api/Lista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lista>> GetLista(int id)
        {
          if (_context.Lista == null)
          {
              return NotFound();
          }
            var lista = await _context.Lista.FindAsync(id);

            if (lista == null)
            {
                return NotFound();
            }

            return lista;
        }

        // PUT: api/Lista/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLista(int id, Lista lista)
        {
            if (id != lista.Id)
            {
                return BadRequest();
            }

            _context.Entry(lista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaExists(id))
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

        // POST: api/Lista
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lista>> PostLista(Lista lista)
        {
          if (_context.Lista == null)
          {
              return Problem("Entity set 'DbList.Lista'  is null.");
          }
            _context.Lista.Add(lista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLista", new { id = lista.Id }, lista);
        }

        // DELETE: api/Lista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLista(int id)
        {
            if (_context.Lista == null)
            {
                return NotFound();
            }
            var lista = await _context.Lista.FindAsync(id);
            if (lista == null)
            {
                return NotFound();
            }

            _context.Lista.Remove(lista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaExists(int id)
        {
            return (_context.Lista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
