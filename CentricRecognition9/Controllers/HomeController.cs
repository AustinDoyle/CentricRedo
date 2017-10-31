﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentricRecognition9.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About using Centric Recognition";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to contact us";

            return View();
        }

        public ActionResult CoreValues()
        {
            ViewBag.Message = "Centric's Core Values";

            return View();
        }

        public ActionResult WIP()
        {
            return View();
        }
    }
}