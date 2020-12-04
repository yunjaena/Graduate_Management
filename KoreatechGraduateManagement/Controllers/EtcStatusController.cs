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
    public class EtcStatusController : Controller
    {
        private readonly MvcEtcStatusContext _context;

        public EtcStatusController(MvcEtcStatusContext context)
        {
            _context = context;
        }

        // GET: EtcStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.EtcStatus.ToListAsync());
        }

        // GET: EtcStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etcStatus = await _context.EtcStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etcStatus == null)
            {
                return NotFound();
            }

            return View(etcStatus);
        }

        // GET: EtcStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EtcStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,IsIPPFinish,IsEngineerCertificationFinish,IsEnglishCertificationFinish")] EtcStatus etcStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etcStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etcStatus);
        }

        // GET: EtcStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etcStatus = await _context.EtcStatus.FindAsync(id);
            if (etcStatus == null)
            {
                return NotFound();
            }
            return View(etcStatus);
        }

        // POST: EtcStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,IsIPPFinish,IsEngineerCertificationFinish,IsEnglishCertificationFinish")] EtcStatus etcStatus)
        {
            if (id != etcStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etcStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtcStatusExists(etcStatus.Id))
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
            return View(etcStatus);
        }

        // GET: EtcStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etcStatus = await _context.EtcStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etcStatus == null)
            {
                return NotFound();
            }

            return View(etcStatus);
        }

        // POST: EtcStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etcStatus = await _context.EtcStatus.FindAsync(id);
            _context.EtcStatus.Remove(etcStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtcStatusExists(int id)
        {
            return _context.EtcStatus.Any(e => e.Id == id);
        }
    }
}
