using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShops.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: ProductManager

        ProductRepository context;

        public ProductManagerController()
        {
            context = new ProductRepository();
        }
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {

            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);

            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");

            }

        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if(product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product,string Id)
        {

            Product producttoedit = context.Find(Id);
            if (producttoedit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(ModelState.IsValid)
                {

                    producttoedit.Name = product.Name;
                    producttoedit.Category = product.Category;
                    producttoedit.Description = product.Description;
                    producttoedit.Price = product.Price;
                    producttoedit.Image = product.Image;
                    context.Commit();
                    return RedirectToAction("Index");

                }

                else
                {
                    return View(product);
                }
            }

        }

        public ActionResult Delete(string Id)
        {
            Product producttodelete = context.Find(Id);
            if(producttodelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producttodelete);

            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product producttodelete = context.Find(Id);

            if (producttodelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");

            }

        }


    }
}