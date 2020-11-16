using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KoreatechGraduateManagement.Data;
using KoreatechGraduateManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace KoreatechGraduateManagement.Controllers
{
    public class SignInController : Controller
    {
        private readonly MvcUserContext _context;

        public SignInController(MvcUserContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,UserID,UserPassword,Name,SchoolD,Grade")] User user)
        {
            if (ModelState.IsValid)
            {
                user.IsAdmin = false;
                _context.Add(user);
                await _context.SaveChangesAsync();
                ViewBag.Result = "회원가입 되었습니다.";
                TempData["Success"] = "Added Successfully!";
                ModelState.Clear();
                return View();
            }
            return View(user);
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]        
        public ActionResult IsIDValid(string id = "")
        {
            return this.Json(new { isValid = !_context.User.Any(e => e.UserID == id) });
        }

     
    }
}