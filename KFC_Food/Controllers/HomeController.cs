using KFC_Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KFC_Food.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KFC_Food.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly KFC_DATAContext _context;

        public HomeController(KFC_DATAContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            TblUser user = null;
            try
            {
                user = JsonConvert.DeserializeObject<TblUser>(HttpContext.Session.GetString("User"));
            }
            catch { }
            if (user != null)
            {
                if (user.RoleId.Equals("AD"))
                {
                    return RedirectToAction("Index", "TblProducts");
                }
            }

            try
            {
                var searchValue = TempData["SearchValue"].ToString();
                ViewData["SearchValue"] = searchValue;
                return View(_context.TblProducts.Where(s => s.ProductName.Contains(searchValue)).ToList());
            }
            catch { } 
            ViewData["Message"] = TempData["Message"];
            return View(_context.TblProducts.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search(IFormCollection form)
        {
            string searchValue = form["searchValue"];
            if (searchValue.Length > 0)
            {
                TempData["SearchValue"] = searchValue;
                return RedirectToAction("Index", "Home");               
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
