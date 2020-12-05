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
    public class StatusController : Controller
    {
        private readonly MvcGraduateManagmentContext _context;



        public StatusController(MvcGraduateManagmentContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index(string userID)
        {
            var userSessionID = HttpContext.Session.GetInt32("Id");
            var status = from m in _context.Status
                         orderby m.Id
                         select m;
            var user = await _context.User.ToListAsync();
            var subject = await _context.Subject.ToListAsync();

            if (user == null || subject.Count < 1)
                return View();

           var query = from a in _context.Status
                        join b in _context.Subject on a.SubjectID equals b.Id
                        join c in _context.User on a.UserID equals c.Id
                        select new StatusInfo
                        {
                            Id = a.Id,
                            UserID = a.UserID,
                            SubjectID = a.SubjectID,
                            UserName = c.UserID,
                            SubjectName = b.SubjectName,
                            Semester = b.Semester,
                            ClassNumber = b.ClassNumber,
                            SubjectType = b.SubjectType,
                            Target = b.Target,
                            ClassTime = b.ClassTime,
                            Credit = b.Credit      
                        };



            if (!String.IsNullOrEmpty(userID))
            {
                query = query.Where(s => s.UserName.Contains(userID));
            }


            if (HttpContext.Session.GetString("Authorize") != "Admin" && userSessionID != null)
            {
                query = query.Where(s => s.UserID == userSessionID);
            }

            var result = await query.ToListAsync();

          
            var statusViewModel = new StatusViewModel
            {
                StatusInfos = result
            };
          


            return View(statusViewModel);
        }


        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,SubjectID")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,SubjectID")] Status status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.Id))
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
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.Status.FindAsync(id);
            _context.Status.Remove(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterSatus([Bind("Id,UserID,SubjectID")] Status status)
        {
            var saveStatus = await _context.Status
               .FirstOrDefaultAsync(m => (m.UserID == status.UserID && m.SubjectID == status.SubjectID));

            if (saveStatus != null)
            {
                return this.Json(new { isSuccess = false, isAlreadyRegistered = true });
            }

            if (status.UserID != null && status.SubjectID != null)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return this.Json(new { isSuccess = true, isAlreadyRegistered = false });
            }

             return this.Json(new { isSuccess = false , isAlreadyRegistered = false });

        }
    }
}
