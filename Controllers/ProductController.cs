using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProducts.Data;
using WebProducts.Models;

namespace WebProducts.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext context = new ProductDbContext();
        // GET: Product

        /*  public ActionResult Index(string category = "")
          {
              if(string.IsNullOrEmpty(category))
              {
                  return View(context.Products.ToList());
              }
              else
              {
                  return View((from p in context.Products
                               where p.Category == category
                               select p).ToList<Product>());
              }
          } */

        public ActionResult Index(string category, string name)
        {
            int cat = String.IsNullOrEmpty(category) ? 0 : 2;
            int nam = String.IsNullOrEmpty(name) ? 0 : 1;
            int val = cat | nam;
         switch(val)
            {
                case 0:
                    return View(context.Products.ToList());
                case 2:
                    return View((from p in context.Products
                                 where p.Category == category
                                 select p).ToList<Product>());
                case 1:
                    return View((from p in context.Products
                                 where p.ProductName == name
                                 select p).ToList<Product>());

                case 3:
                    return View((from p in context.Products
                                 where p.Category == category &&  p.ProductName == name select p).ToList<Product>());

                default:
                    return View(); 
            }
        }



        public ActionResult Detail(int id)
        {
            Product producto = context.Products.Find(id);
            if(producto != null)
            {
                return View("Detail", producto);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product producto = context.Products.Find(id);
            if (producto != null)
            {
                return View("Edit", producto);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", product);
        }

        [HttpGet] 
        public ActionResult Create()
        {
            Product producto = new Product();
            return View("Create", producto);
        }

        [HttpPost]
        public ActionResult Create(Product producto)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(producto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", producto);
        }

        public ActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                return View("Delete", product);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}