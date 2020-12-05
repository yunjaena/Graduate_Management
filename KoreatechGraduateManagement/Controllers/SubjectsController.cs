using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoreatechGraduateManagement.Data;
using KoreatechGraduateManagement.Models;
using Microsoft.AspNetCore.Http;

namespace KoreatechGraduateManagement.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly MvcGraduateManagmentContext _context;

        public SubjectsController(MvcGraduateManagmentContext context)
        {
            _context = context;
        }

    
        public async Task<IActionResult> Index(string subjectSemester,  string searchString)
        {


            IQueryable<string> semesterQuery = from m in _context.Subject
                                            orderby m.Semester
                                            select m.Semester;

            var subject = from m in _context.Subject
                          select m;

            if (!String.IsNullOrEmpty(subjectSemester))
            {
                subject = subject.Where(s => s.Semester.Contains(subjectSemester));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                subject = subject.Where(s => s.SubjectName.Contains(searchString)).OrderBy(s => s.Semester);
            }

            var subjectVM = new SubjectViewModel
            {
                Semesters = new SelectList(await semesterQuery.Distinct().ToListAsync()),
                Subjects = await subject.ToListAsync()
            };

            return View(subjectVM);
        }


        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Authorize") != "Admin")
                return NotFound();

            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectName,Semester,SubjectCode,ClassNumber,SubjectType,Target,ClassTime,Credit")] Subject subject)
        {
            if (HttpContext.Session.GetString("Authorize") != "Admin")
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Authorize") != "Admin")
                return NotFound();

            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectName,Semester,SubjectCode,ClassNumber,SubjectType,Target,ClassTime,Credit")] Subject subject)
        {
            if (HttpContext.Session.GetString("Authorize") != "Admin")
                return NotFound();

            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Authorize") != "Admin")
                return NotFound();

            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Authorize") != "Admin")
                return NotFound();

            var subject = await _context.Subject.FindAsync(id);
            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }

    }
}
