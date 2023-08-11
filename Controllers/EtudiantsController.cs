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
    public class EtudiantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            var gestionEtudiantContext = _context.Etudiant.Include(i => i.Faculte);
            return View(await gestionEtudiantContext.ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant
                .Include(i => i.Faculte)
                .FirstOrDefaultAsync(m => m.EtudiantID == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            var facultesAvecNiveaux = _context.Faculte.Include(f => f.Niveaux).ToList();
            var selectList = new List<SelectListItem>();

            foreach (var faculte in facultesAvecNiveaux)
            {
                if (faculte.Niveaux != null)
                {
                    foreach (var niveau in faculte.Niveaux)
                    {
                        var optionText = $"{faculte.Libelle} - {niveau.Libelle}";

                        selectList.Add(new SelectListItem
                        {
                            Text = optionText,
                            Value = niveau.NiveauId.ToString()
                        });
                    }
                }
            }

            ViewData["FaculteId"] = new SelectList(selectList, "Value", "Text");
            ViewData["Sexe"] = new SelectList(Enum.GetValues(typeof(Etudiant.Genre)));
            return View();

        }



        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtudiantID,Matricule,Prenom,Nom,Sexe,age,Adresse,Email,Telephone,typeEtudiant,FaculteId")] Etudiant etudiant)
        {
            _context.Add(etudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtudiantID,Matricule,Prenom,Nom,Sexe,age,Adresse,Email,Telephone,typeEtudiant")] Etudiant etudiant)
        {
            if (id != etudiant.EtudiantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.EtudiantID))
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
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etudiant == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiant
                .FirstOrDefaultAsync(m => m.EtudiantID == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etudiant == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Etudiant'  is null.");
            }
            var etudiant = await _context.Etudiant.FindAsync(id);
            if (etudiant != null)
            {
                _context.Etudiant.Remove(etudiant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
          return (_context.Etudiant?.Any(e => e.EtudiantID == id)).GetValueOrDefault();
        }
    }
}
