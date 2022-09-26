using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;


namespace Project1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        ProductsData obj = new ProductsData();
        public ViewResult Details(int id)
        {
            Product p = obj.ProductsList.Single(m => m.ProductId == id);
            return View(p);
        }
    }
}