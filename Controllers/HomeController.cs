using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingBronies.Models;
using Microsoft.EntityFrameworkCore;

namespace TradingBronies.Controllers
{
    public class HomeController : Controller
    {

        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return Redirect($"/profile/{newUser.UserId}");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("profile/{userId}")]
        public IActionResult Dashboard(int userId)
        {
            User signedIn = _context.Users.Include( u => u.MyLittleBronies ).FirstOrDefault( u => u.UserId == userId);
            return View(signedIn);
        }


        [HttpPost("create/brony")]
        public IActionResult CreateBrony(Brony newBrony)
        {
            _context.Bronies.Add(newBrony);
            _context.SaveChanges();
            return Redirect($"/profile/{newBrony.UserId}");
            
        }

        [HttpGet("gluefactory")]
        public IActionResult GlueFactory()
        {
            List<Brony> AllBronies = _context.Bronies.Include( b => b.Owner ).ToList();

            return View(AllBronies);
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
