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
    public class GerenciaController : Controller
    {
        private AppDbContext _context;

        public GerenciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostGerencia([FromBody] Gerencia gerencia)
        {
            var g = gerencia;
            _context.Gerencias.Add(g);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGerenciaPorId), new {Id = gerencia.Id}, gerencia);    
        }

        [HttpGet]
        public IEnumerable<Gerencia> GetGerencias() => _context.Gerencias;

        [HttpGet("{id}")]
        public IActionResult GetGerenciaPorId(int id)
        {
            var gerencias = _context.Gerencias;
            var gerencia = gerencias.FirstOrDefault(gerencia => gerencia.Id == id);
            if (gerencia != null)
            {
                return Ok(gerencia);
            }
            return NotFound();
        }   

        [HttpDelete("{id}")]
        public IActionResult DeleteGerencia([FromBody] int id)
        {
            var gerencias = _context.Gerencias;
            var gerencia = gerencias.FirstOrDefault(gerencia => gerencia.Id == id);
            if (gerencia != null)
            {
                _context.Remove(gerencia);
                _context.SaveChanges();
                return NoContent();
            }
                return NotFound();    
        }
    }
}