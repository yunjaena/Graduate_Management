using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using KoreatechGraduateManagement.Data;
using KoreatechGraduateManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KoreatechGraduateManagement.Controllers
{
    public class SignInController : Controller
    {
        private readonly MvcGraduateManagmentContext _context;

        public SignInController(MvcGraduateManagmentContext context)
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
                user.UserPassword = GetMD5(user.UserPassword);
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


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}