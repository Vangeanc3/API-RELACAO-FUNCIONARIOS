using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : Controller
    {
            private AppDbContext _context;

        public GerenteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostGerente([FromBody] Gerente gerente)
        {
            var g = gerente;
            _context.Add(g);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGerentesPorId), new {Id = gerente.Id}, gerente);    
        }

        [HttpGet]
        public IEnumerable<Gerente> GetGerentes([FromQuery] string nomeGere)
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]
        public IActionResult GetGerentesPorId(int id)
        {
            var gerentes = _context.Gerentes;
            var gerente = gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                return Ok(gerente);
            }
            return NotFound();
        }   

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente([FromBody] int id)
        {
            var gerentes = _context.Gerentes;
            var gerente = gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                return NoContent();
            }
                return NotFound();    
        }
    }
}