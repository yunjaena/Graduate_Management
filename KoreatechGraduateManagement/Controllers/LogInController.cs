using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KoreatechGraduateManagement.Data;
using KoreatechGraduateManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoreatechGraduateManagement.Controllers
{
    public class LogInController : Controller
    {

        private readonly MvcUserContext _context;
      

        public LogInController(MvcUserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string userId, string userPassword)
        {
            if (userId != null && userPassword != null)
            {
                var f_password = GetMD5(userPassword);
                var data = _context.User.Where(s => s.UserID.Equals(userId) && s.UserPassword.Equals(f_password)).ToList();

                if (data.Count() > 0)
                {
                    //add session
                    HttpContext.Session.SetString("Name", data.FirstOrDefault().Name);
                    HttpContext.Session.SetInt32("Id", data.FirstOrDefault().Id);
                    if(data.FirstOrDefault().IsAdmin)
                        HttpContext.Session.SetString("Authorize", "Admin");
                    else
                        HttpContext.Session.SetString("Authorize", "User");

                    return Redirect("~/");
                }
                else
                {
                    ViewBag.Error = "로그인에 실패했습니다.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "아이디 비번을 입력해주세요.";
                return View();
            }
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