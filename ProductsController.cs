using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
       // public ActionResult Index()
       
       //to access the members of ProductsData class ,we create object.
            ProductsData db = new ProductsData();
            public ViewResult Details(int id)
        {
            //Linq Method ,used to perform iteration over the collection & identifies the value which is matching with expression we have defined and returns that value.
            Products p = db.ProductsList.Single(x => x.ProductId == id);
            return View(p);
        }

        
    }
}