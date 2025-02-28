using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_AG_652_2022_FS_651.Models;

namespace P01_2022_AG_652_2022_FS_651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SucursalesController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursales>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        // Obtener sucursal por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursales>> GetSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();
            return sucursal;
        }

        // Crear una nueva sucursal
        [HttpPost]
        public async Task<ActionResult<Sucursales>> CreateSucursal(Sucursales sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.Id }, sucursal);
        }

        // Actualizar una sucursal
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSucursal(int id, Sucursales sucursal)
        {
            if (id != sucursal.Id) return BadRequest();
            _context.Entry(sucursal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar una sucursal
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();
            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
