using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KoreatechGraduateManagement.Controllers
{
    public class RegisterClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}