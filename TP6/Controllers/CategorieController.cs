using Microsoft.AspNetCore.Mvc;
using TP6.Models;
using TP6.Repositories;

namespace TP6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategorieController : ControllerBase
    {
      
        private readonly ICategorieRepository _repo;

        public CategorieController(ICategorieRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _repo.GetById(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categorie cat)
        {
            var newCat = await _repo.Add(cat);
            return CreatedAtAction(nameof(GetById), new { id = newCat.Id }, newCat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Categorie cat)
        {
            var updated = await _repo.Update(id, cat);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

