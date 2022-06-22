﻿ using Microsoft.AspNetCore.Mvc;
using SalesWeb.Services;
using System;
using System.Threading.Tasks;

namespace SalesWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {

            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year,1, 1);
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
    }
}
