using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_AG_652_2022_FS_651.Models;

namespace ParqueoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaciosParqueoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EspaciosParqueoController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los espacios de parqueo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspaciosParqueo>>> GetEspacios()
        {
            return await _context.EspaciosParqueo.ToListAsync();
        }

        // Obtener un espacio por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EspaciosParqueo>> GetEspacio(int id)
        {
            var espacio = await _context.EspaciosParqueo.FindAsync(id);
            if (espacio == null) return NotFound();
            return espacio;
        }

        // Crear un nuevo espacio
        [HttpPost]
        public async Task<ActionResult<EspaciosParqueo>> CreateEspacio(EspaciosParqueo espacio)
        {
            _context.EspaciosParqueo.Add(espacio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEspacio), new { id = espacio.Id }, espacio);
        }

        // Actualizar un espacio de parqueo
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEspacio(int id, EspaciosParqueo espacio)
        {
            if (id != espacio.Id) return BadRequest();
            _context.Entry(espacio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar un espacio de parqueo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspacio(int id)
        {
            var espacio = await _context.EspaciosParqueo.FindAsync(id);
            if (espacio == null) return NotFound();
            _context.EspaciosParqueo.Remove(espacio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

