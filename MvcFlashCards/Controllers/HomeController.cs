using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcFlashCards.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFlashCards.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(int laro)
        {
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
