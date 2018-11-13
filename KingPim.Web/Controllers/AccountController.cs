﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        
        public IActionResult Index()
        {
            // Have the whole King Pim site access here...
            return View();
        }

      


    }
}