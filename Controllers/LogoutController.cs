﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digital_Diary.Controllers
{
    public class LogoutController : Controller
    {
        
        public ActionResult Index()
        {
            Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}