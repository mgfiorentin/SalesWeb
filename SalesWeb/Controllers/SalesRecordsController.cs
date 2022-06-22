using Microsoft.AspNetCore.Mvc;
using SalesWeb.Models.ViewModel;
using SalesWeb.Models;
using SalesWeb.Services;
using System;
using System.Threading.Tasks;
using SalesWeb.Services.Exceptions;
using SalesWeb.Models.ViewModels;
using System.Diagnostics;

namespace SalesWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;
        private readonly DepartmentService _departmentService;

        public SalesRecordsController(SalesRecordService salesRecordService, DepartmentService departmentService)
        {
            _salesRecordService = salesRecordService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {

            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = DateTime.Now;
            var sales = await _salesRecordService.FindByDateAsync(minDate, maxDate);

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            return View(sales);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = DateTime.Now;
            var sales = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            return View(sales);

        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalesRecord sr)
        {
            var obj = _salesRecordService.FindById(sr.Seller.Id);
            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            _salesRecordService.RegisterSale(sr);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }





    }
}
