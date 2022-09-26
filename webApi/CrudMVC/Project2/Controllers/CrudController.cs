using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2.Dbconn;
using Project2.Models;
using System.Web.Security;
using System.Net.Http;
using Newtonsoft.Json;

namespace Project2.Controllers
{
    [Authorize]
    public class CrudController : Controller
    {
        // GET: Crud
        [HttpGet]
        public ActionResult Index()                  //---------------------------------Table-------------------------------
        {
            // MyProjectEntities obj = new MyProjectEntities();
            //var res = obj.Emps.ToList();
            HttpClient client = new HttpClient(); 
           
            //GetAsync will hit the data on Url and gets data & after that we need to read data.
            var abc = client.GetAsync("http://localhost:50385/Emp/GetList").Result;
           
            //to read data.
            string data = abc.Content.ReadAsStringAsync().Result;
            
//to convert the data from Json to our class (EmpClass) object then we use two ways-----1)Serialization[class obj to Json] 2)Deserializtion[Json to Class obj].
            var res = JsonConvert.DeserializeObject<List<EmpClass>>(data);
           
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
        public ActionResult EmpAllDetails()                  //---------------------------------Stored Procedure-------------------------------
        {
            // MyProjectEntities obj = new MyProjectEntities();
            //var res = obj.Emps.ToList();
            HttpClient client = new HttpClient();

            //GetAsync will hit the data on Url and gets data & after that we need to read data.
            var abc = client.GetAsync("http://localhost:50385/Emp/GetListAll").Result;

            //to read data.
            string data = abc.Content.ReadAsStringAsync().Result;

            //to convert the data from Json to our class (EmpClass) object then we use two ways-----1)Serialization[class obj to Json] 2)Deserializtion[Json to Class obj].
            var res = JsonConvert.DeserializeObject<List<GetAllDataModel>>(data);

            return View(res);
        }





        public ActionResult Delete(int id)
        {
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
        [HttpPost]
        public ActionResult Add(EmpClass c)
        {
            HttpClient client = new HttpClient();
           
            //it wiil convert the value (which we will send from ui ) from class object to json format .
            string data = JsonConvert.SerializeObject(c);
            
            // we have to send 3 things-data(which have been changed in json),utf ,application/json(type of content).
            StringContent abc = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
           
            //this link will hit the api and it wil get the data here which client have send from ui side.
            //through this link,we can send data from any application.when we were restricted to use only our application that was tightly coupled.
            //now it is open source so,it loosely coupled.
            var abcd = client.PostAsync("http://localhost:50071/Emp/Save",abc).Result;
            
           // MyProjectEntities obj = new MyProjectEntities();
            
           //create object of emptable
           /* Emp data = new Emp();
            data.id = c.id;
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
            }*/
           
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
            return RedirectToAction("Login");
        }
            
    }
}