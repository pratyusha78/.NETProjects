using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2.Dbconn;
using Project2.Models;
using System.Web.Security;

namespace Project2.Controllers
{
    [Authorize]
    public class CrudController : Controller
    {
        // GET: Crud
        [HttpGet]
        public ActionResult Index()
        {
            MyProjectEntities obj = new MyProjectEntities();
            var res = obj.Emps.ToList();
            List<EmpClass> conn = new List<EmpClass>();
            foreach (var item in res)
            {
                conn.Add(new EmpClass { 
                    id = item.id,
                    Name = item.Name, 
                    Email = item.Email,
                    Mobile = item.Mobile, 
                    Company = item.Company, 
                    Dept = item.Dept, 
                    Salary = item.Salary });
            }
            return View(conn);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Delete(int id)
        {
            //to connect with database to perform all tasks.
            MyProjectEntities obj = new MyProjectEntities();
            var deleteitem = obj.Emps.Where(m => m.id == id).First();
            obj.Emps.Remove(deleteitem);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
       
        
        [HttpPost]     //to receive the data from form
        [ValidateAntiForgeryToken]
        public ActionResult Add(EmpClass c)//it will bring the data here from view(the submitted data in the form)
        {
            MyProjectEntities obj = new MyProjectEntities();
            //create object of emptable
            Emp data = new Emp(); //object,where data will be received
            data.id = c.id; //data aaigned here and then sent to emp object.
            data.Name = c.Name;
            data.Email = c.Email;
            data.Mobile = c.Mobile;
            data.Company = c.Company;
            data.Dept = c.Dept;
            data.Salary = c.Salary;
           
            if (c.id == 0)
            {
                obj.Emps.Add(data);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(data).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            MyProjectEntities obj = new MyProjectEntities();
            var edititem = obj.Emps.Where(m => m.id == id).First();
            //create obj of emp table
            EmpClass c = new EmpClass();
            c.id = edititem.id;
            c.Name = edititem.Name;
            c.Email = edititem.Email;
            c.Mobile = edititem.Mobile;
            c.Company = edititem.Company;
            c.Dept = edititem.Dept;
            c.Salary = edititem.Salary;
            ViewBag.edit = "Edit";
            return View("Add",c);
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginClass l)
        {
            MyProjectEntities obj = new MyProjectEntities();
            var res = obj.Logins.Where(m => m.Email == l.Email).FirstOrDefault();
            if (res == null)
            {
                TempData["InvalidEmail"] = "Email does not exist";
            }
            else
            {
                if(res.Email==l.Email && res.Password == l.Password)
                {
                    FormsAuthentication.SetAuthCookie(res.Email, false);
                    Session["id"] = res.id;
                    Session["Email"] = res.Email;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InvalidPassword"] = "Password incorrect";
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(LoginClass l)
        {
            MyProjectEntities obj = new MyProjectEntities();
            //create obj of login table
            Login data = new Login();
            data.Email = l.Email;
            data.Password = l.Password;
            obj.Logins.Add(data);
            obj.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
            
    }
}