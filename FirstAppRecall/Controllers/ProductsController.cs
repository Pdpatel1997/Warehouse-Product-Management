using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FirstAppRecall.Models;

namespace FirstAppRecall.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Products
        public ActionResult Index(string search="",string SortColumn="ProductName",string IconClass="fa-sort-asc",int PageNo=1)
        {
            List<Product> products = db.Products.Where(s=>s.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
            ViewBag.IconClass = IconClass;
            ViewBag.SortColumn = SortColumn;

            //Sorting
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.ProductID).ToList();
                else
                    products = products.OrderByDescending(s => s.ProductID).ToList();
            }
            if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.ProductName).ToList();
                else
                    products = products.OrderByDescending(s => s.ProductName).ToList();
            }
            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.Price).ToList();
                else
                    products = products.OrderByDescending(s => s.Price).ToList();
            }
            if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(s => s.DateOfPurchase).ToList();
            }
            if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(s => s.AvailabilityStatus).ToList();
            }
            if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.CategoryID).ToList();
                else
                    products = products.OrderByDescending(s => s.CategoryID).ToList();
            }
            if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(s => s.BrandID).ToList();
                else
                    products = products.OrderByDescending(s => s.BrandID).ToList();
            }

           
            return View(products);

            

        }

        public ActionResult Details(int id)
        {
            Product product = db.Products.Where(s => s.ProductID == id).SingleOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            List<Category> categories = db.Categories.ToList();
            ViewBag.Cat = categories;
            List<Brand> brands = db.Brands.ToList();
            ViewBag.Brand = brands;
            return View();

        }

        [HttpPost]
        public ActionResult Create(Product product)

        {
            if (ModelState.IsValid)
            {

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                List<Category> categories = db.Categories.ToList();
                ViewBag.Cat = categories;
                List<Brand> brands = db.Brands.ToList();
                ViewBag.Brand = brands;
                return View();
            }
        }

        

        public ActionResult Edit(int id)
        {
            Product existingProduct = db.Products.Where(s => s.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            Product existingProduct = db.Products.Where(s => s.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.Active = p.Active;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Product existingProduct = db.Products.Where(s => s.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var pro = db.Products.Where(s => s.ProductID == product.ProductID).SingleOrDefault();
            db.Products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}