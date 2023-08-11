using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Etudiants_App_Web.Data;
using Gestion_Etudiants_App_Web.Models;

namespace Gestion_Etudiants_App_Web.Controllers
{
    public class FacultesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultesController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: Facultes
        public async Task<IActionResult> Index()
        {
              return _context.Faculte != null ? 
                          View(await _context.Faculte.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Faculte'  is null.");
        }

        // GET: Facultes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Faculte == null)
            {
                return NotFound();
            }

            var faculte = await _context.Faculte
                .FirstOrDefaultAsync(m => m.FaculteId == id);
            if (faculte == null)
            {
                return NotFound();
            }

            return View(faculte);
        }

        // GET: Facultes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facultes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaculteId,Libelle,Telephone,Email")] Faculte faculte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculte);
        }

        // GET: Facultes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Faculte == null)
            {
                return NotFound();
            }

            var faculte = await _context.Faculte.FindAsync(id);
            if (faculte == null)
            {
                return NotFound();
            }
            return View(faculte);
        }

        // POST: Facultes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaculteId,Libelle,Telephone,Email")] Faculte faculte)
        {
            if (id != faculte.FaculteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaculteExists(faculte.FaculteId))
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
            return View(faculte);
        }

        // GET: Facultes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Faculte == null)
            {
                return NotFound();
            }

            var faculte = await _context.Faculte
                .FirstOrDefaultAsync(m => m.FaculteId == id);
            if (faculte == null)
            {
                return NotFound();
            }

            return View(faculte);
        }

        // POST: Facultes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Faculte == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Faculte'  is null.");
            }
            var faculte = await _context.Faculte.FindAsync(id);
            if (faculte != null)
            {
                _context.Faculte.Remove(faculte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaculteExists(int id)
        {
          return (_context.Faculte?.Any(e => e.FaculteId == id)).GetValueOrDefault();
        }
    }
}
