using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
using SalesWeb.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly SalesRecordService _salesRecordService;
   

        public HomeController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
                    }

        public async Task<IActionResult> Index()
        {
            var lastSales = await _salesRecordService.FindLastTenAsync();

            return View(lastSales);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Web MVC Sales App from C# Course";

            return View();
        }
              

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
