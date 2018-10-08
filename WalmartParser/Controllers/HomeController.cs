﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            
            return View(db.Shoes.ToList());
        }
    }
}
