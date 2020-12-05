using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoreatechGraduateManagement.Data;
using KoreatechGraduateManagement.Models;

namespace KoreatechGraduateManagement.Controllers
{
    public class GraduateCreditsController : Controller
    {
        private readonly MvcGraduateManagmentContext _context;

        public GraduateCreditsController(MvcGraduateManagmentContext context)
        {
            _context = context;
        }

        // GET: GraduateCredits
        public async Task<IActionResult> Index()
        {
            return View(await _context.GraduateCredit.ToListAsync());
        }

        // GET: GraduateCredits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graduateCredit = await _context.GraduateCredit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graduateCredit == null)
            {
                return NotFound();
            }

            return View(graduateCredit);
        }

        // GET: GraduateCredits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GraduateCredits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntranceYear,TotalGraduateCredit,ElectivesNormalCredit,ElectivesNecessaryCredit,CoreClassNormalCredit,CoreClassNecessaryCredit,HRDNormalCredit,HRDClassNecessaryCredit,MSCNormalCredit,MSCNecessaryCredit,FreeCredit")] GraduateCredit graduateCredit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graduateCredit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(graduateCredit);
        }

        // GET: GraduateCredits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graduateCredit = await _context.GraduateCredit.FindAsync(id);
            if (graduateCredit == null)
            {
                return NotFound();
            }
            return View(graduateCredit);
        }

        // POST: GraduateCredits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntranceYear,TotalGraduateCredit,ElectivesNormalCredit,ElectivesNecessaryCredit,CoreClassNormalCredit,CoreClassNecessaryCredit,HRDNormalCredit,HRDClassNecessaryCredit,MSCNormalCredit,MSCNecessaryCredit,FreeCredit")] GraduateCredit graduateCredit)
        {
            if (id != graduateCredit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graduateCredit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraduateCreditExists(graduateCredit.Id))
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
            return View(graduateCredit);
        }

        // GET: GraduateCredits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graduateCredit = await _context.GraduateCredit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graduateCredit == null)
            {
                return NotFound();
            }

            return View(graduateCredit);
        }

        // POST: GraduateCredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graduateCredit = await _context.GraduateCredit.FindAsync(id);
            _context.GraduateCredit.Remove(graduateCredit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraduateCreditExists(int id)
        {
            return _context.GraduateCredit.Any(e => e.Id == id);
        }
    }
}
