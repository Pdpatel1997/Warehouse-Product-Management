﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstAppRecall.Models;
namespace FirstAppRecall.Controllers
{
    public class BrandsController : Controller
    {
        EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
        // GET: Brands
        public ActionResult Index()
        {
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}