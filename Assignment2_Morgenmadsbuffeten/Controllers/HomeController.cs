using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Morgenmadsbuffeten.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment2_Morgenmadsbuffeten.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SQLitePCL;

namespace Assignment2_Morgenmadsbuffeten.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            
            return View();
        }

        [AllowAnonymous]
        public ActionResult Kitchen(DateTime guestDate)
        {
            //DateTime date = DateTime.Today;
            if (guestDate.Year == 1)
            {
                guestDate = DateTime.Today;
            }

            

            var viewModel = new GuestViewModel
            {
                CheckedInGuests = _context.CheckedInGuests.ToList()
                    //.Include(i => i.Adult)
                    //.Include(i => i.Children)
                    //.OrderBy(i => i.Date)
                , ExpectedGuests = _context.ExpectedGuests.ToList()
                    //.Include(i => i.Children)
                    //.Include(i => i.Children)
                    //.OrderBy(i=> i.Date)
            };

            viewModel.GuestDate = guestDate;

           
                viewModel.CheckedInGuests = viewModel.CheckedInGuests.Where
                    (i => i.Date.Day == guestDate.Day).ToList();
                viewModel.CheckedInAdults = 0;
                viewModel.CheckedInChildren = 0;
                foreach (var guest in viewModel.CheckedInGuests )
                {
                    viewModel.CheckedInAdults += guest.Adults;
                    viewModel.CheckedInChildren += guest.Children;

                }

                //viewModel.CheckedInGuests = viewModel.CheckedInGuests.Where
                //    (i => i.Date == date).ToList().

                viewModel.ExpectedGuests = viewModel.ExpectedGuests.Where
                    (i => i.Date.Day == guestDate.Day).ToList();
                viewModel.ExpectedAdults = 0;
                viewModel.ExpectedChildren = 0;
                foreach (var guest in viewModel.ExpectedGuests)
                {
                    viewModel.ExpectedAdults += guest.Adults;
                    viewModel.ExpectedChildren += guest.Children;

                }



            return View(viewModel);
            //return View();
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
    }
}
