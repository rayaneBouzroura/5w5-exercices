using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _5W5_EXO01.Data;
using _5W5_EXO01.Models;

namespace _5W5_EXO01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatModelsController : Controller
    {
        private readonly _5W5_EXO01Context _context;

        public CatModelsController(_5W5_EXO01Context context)
        {
            _context = context;
        }

        // GET: Admin/CatModels
        public async Task<IActionResult> Index()
        {
            SeedData();

              return _context.CatModel != null ? 
                          View(await _context.CatModel.ToListAsync()) :
                          Problem("Entity set '_5W5_EXO01Context.CatModel'  is null.");
        }

        // GET: Admin/CatModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatModel == null)
            {
                return NotFound();
            }

            var catModel = await _context.CatModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (catModel == null)
            {
                return NotFound();
            }

            return View(catModel);
        }

        // GET: Admin/CatModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CatModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,image")] CatModel catModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catModel);
        }

        // GET: Admin/CatModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatModel == null)
            {
                return NotFound();
            }

            var catModel = await _context.CatModel.FindAsync(id);
            if (catModel == null)
            {
                return NotFound();
            }
            return View(catModel);
        }

        // POST: Admin/CatModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,image")] CatModel catModel)
        {
            if (id != catModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatModelExists(catModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catModel);
        }

        // GET: Admin/CatModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatModel == null)
            {
                return NotFound();
            }

            var catModel = await _context.CatModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (catModel == null)
            {
                return NotFound();
            }

            return View(catModel);
        }

        // POST: Admin/CatModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatModel == null)
            {
                return Problem("Entity set '_5W5_EXO01Context.CatModel'  is null.");
            }
            var catModel = await _context.CatModel.FindAsync(id);
            if (catModel != null)
            {
                _context.CatModel.Remove(catModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatModelExists(int id)
        {
          return (_context.CatModel?.Any(e => e.id == id)).GetValueOrDefault();
        }


        //method to seed some cats
        private void SeedData()
        {
            if (!_context.CatModel.Any())
            {
                _context.CatModel.AddRange(
                    new CatModel { name = "Cat 1", image = "https://images.unsplash.com/photo-1608848461950-0fe51dfc41cb?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxleHBsb3JlLWZlZWR8MXx8fGVufDB8fHx8fA%3D%3D" },
                    new CatModel { name = "Cat 2", image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX9A_f_jDYExfolsAhVX7IgctPaA9qU0KUg&s" },
                    new CatModel { name = "Cat 2", image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHjQzMaiAHTUrzQAcq0hxckWeFKaMT-9UA3w&s" }
                // Add more cats as needed...
                );

                _context.SaveChanges();
            }
        }
    }


    

}
