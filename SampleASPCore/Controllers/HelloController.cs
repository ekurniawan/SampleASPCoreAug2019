﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleASPCore.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return Content("About");
        }

        public IActionResult Contact()
        {
            return Content("Contact");
        }

        public IActionResult Tentang()
        {
            return Content("tentang aplikasi ini");
        }
    }
}