using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalmartParser.Models;

namespace WalmartParser.Controllers
{
    public class HomeController : Controller
    {
        private ShoesContext db;
        public HomeController(ShoesContext context)
        {
            db = context;

        }
        public IActionResult Index()
        {
            //List<ShoesDb> viewShoes = new List<ShoesDb>();
            //viewShoes = db.Shoes.ToList();
            ViewBag.shoes = db.Shoes;
            return View();
        }
    }
}
