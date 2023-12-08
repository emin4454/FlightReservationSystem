﻿using FlightReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FlightReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestDbContext _context;
        public HomeController(TestDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var Humans = _context.Humans.ToList();
            return View(Humans);
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