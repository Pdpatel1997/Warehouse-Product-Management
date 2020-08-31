using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstAppRecall.Models;
namespace FirstAppRecall.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}