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
    public class NiveauxController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NiveauxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Niveaux
        public async Task<IActionResult> Index()
        {
            var gestionEtudiantContext = _context.Niveau.Include(i => i.Faculte);
            return View(await gestionEtudiantContext.ToListAsync());
        }

        // GET: Niveaux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Niveau == null)
            {
                return NotFound();
            }

            var niveau = await _context.Niveau
                .Include(i => i.Faculte)
                .FirstOrDefaultAsync(m => m.NiveauId == id);
            if (niveau == null)
            {
                return NotFound();
            }

            return View(niveau);
        }

        // GET: Niveaux/Create
        public IActionResult Create()
        {
            var requete = from f in _context.Set<Faculte>()
                          select new
                          {
                              libelle = f.Libelle,
                              value = f.FaculteId
                          };
            var listeFacultes = requete.Select(i => new SelectListItem()
            {
                Text = i.libelle,
                Value = i.value.ToString()
            }
            ).ToList();

            ViewBag.Faculte = listeFacultes;
            //ViewData["Faculte"] = new SelectList(_context.Faculte, "FaculteId", "Libelle");
            return View();
        }

        // POST: Niveaux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NiveauId,Libelle,FaculteId")] Niveau niveau)
        {
                _context.Add(niveau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Niveaux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Niveau == null)
            {
                return NotFound();
            }

            var niveau = await _context.Niveau.FindAsync(id);
            if (niveau == null)
            {
                return NotFound();
            }
            ViewData["FaculteId"] = new SelectList(_context.Set<Faculte>(),"FaculteId", "Libelle", niveau.FaculteId);
            return View(niveau);
        }

        // POST: Niveaux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NiveauId,Libelle,FaculteId")] Niveau niveau)
        {
            if (id != niveau.NiveauId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Récupérer l'entité "Faculte" correspondant à l'identifiant "FaculteId" sélectionné
                    var faculte = await _context.Faculte.FirstOrDefaultAsync(f => f.FaculteId == niveau.FaculteId);

                    // Vérifier si la faculté existe avant de l'assigner au modèle "Niveau"
                    if (faculte != null)
                    {
                        niveau.Faculte = faculte;
                    }
                    else
                    {
                        // Gérer le cas où la faculté n'est pas trouvée, par exemple, afficher un message d'erreur
                        ModelState.AddModelError("FaculteId", "Faculte introuvable.");
                    }
                    _context.Update(niveau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NiveauExists(niveau.NiveauId))
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
            ViewData["FaculteId"] = new SelectList(_context.Faculte, "FaculteId", "Libelle", niveau.FaculteId);
            return View(niveau);
        }

        // GET: Niveaux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Niveau == null)
            {
                return NotFound();
            }

            var niveau = await _context.Niveau
                .Include(i => i.Faculte)
                .FirstOrDefaultAsync(m => m.NiveauId == id);
            if (niveau == null)
            {
                return NotFound();
            }

            return View(niveau);
        }

        // POST: Niveaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Niveau == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Niveau'  is null.");
            }
            var niveau = await _context.Niveau.FindAsync(id);
            if (niveau != null)
            {
                _context.Niveau.Remove(niveau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NiveauExists(int id)
        {
          return (_context.Niveau?.Any(e => e.NiveauId == id)).GetValueOrDefault();
        }
    }
}
