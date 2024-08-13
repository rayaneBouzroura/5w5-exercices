using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _5W5_EXO01.Data;
using _5W5_EXO01.Models;

namespace _5W5_EXO01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatModelsController : ControllerBase
    {
        private readonly _5W5_EXO01Context _context;

        public CatModelsController(_5W5_EXO01Context context)
        {
            _context = context;
        }

        // GET: api/CatModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatModel>>> GetCatModel()
        {
          if (_context.CatModel == null)
          {
              return NotFound();
          }
            return await _context.CatModel.ToListAsync();
        }

        // GET: api/CatModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatModel>> GetCatModel(int id)
        {
          if (_context.CatModel == null)
          {
              return NotFound();
          }
            var catModel = await _context.CatModel.FindAsync(id);

            if (catModel == null)
            {
                return NotFound();
            }

            return catModel;
        }

        // PUT: api/CatModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatModel(int id, CatModel catModel)
        {
            if (id != catModel.id)
            {
                return BadRequest();
            }

            _context.Entry(catModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatModelExists(id))
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

        // POST: api/CatModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatModel>> PostCatModel(CatModel catModel)
        {
          if (_context.CatModel == null)
          {
              return Problem("Entity set '_5W5_EXO01Context.CatModel'  is null.");
          }
            _context.CatModel.Add(catModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatModel", new { id = catModel.id }, catModel);
        }

        // DELETE: api/CatModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatModel(int id)
        {
            if (_context.CatModel == null)
            {
                return NotFound();
            }
            var catModel = await _context.CatModel.FindAsync(id);
            if (catModel == null)
            {
                return NotFound();
            }

            _context.CatModel.Remove(catModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatModelExists(int id)
        {
            return (_context.CatModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
