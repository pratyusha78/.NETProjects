using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1_Core.Database_conn;
using Project1_Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_Core.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public HomeController(ApplicationDbContext db)
        {
            _Db = db;
        }

        public IActionResult Index()
        {

            var res = _Db.Employeeies.ToList();


            return View(res);
        }

        public IActionResult Delete(int Id)
        {

            var res = _Db.Employeeies.Where(a => a.Id == Id).First();

            _Db.Employeeies.Remove(res);

            _Db.SaveChanges();

            //return View(res);

            return RedirectToAction("Index");
        }

        public IActionResult AddEmp()
        {


            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Employee obj)
        {

            if (obj.Id == 0)
            {
                _Db.Employeeies.Add(obj);
                _Db.SaveChanges();


            }

            else
            {
                _Db.Employeeies.Update(obj);
                _Db.SaveChanges();


            }

            // return View();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {

            var res = _Db.Employeeies.Where(a => a.Id == Id).First();


            //return View();

            return View("AddEmp", res);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
