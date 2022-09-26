using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiProject.DBConn;
using ApiProject.Models;

namespace ApiProject.Controllers

{
    public class EmpController : ApiController
    {
        //by default [httpget]
        [Route("Pratyusha/GetList")]
        public List<string> GetListName()
        {
            List<string> objlist = new List<string>()
            {
                "sam1",
                "sam2",
                "sam3",
                "sam4",
                "sam5"
            };
            return objlist;
        }
        [Route("Priya/GetList")]
        public List<string> GetListName2()
        {
            List<string> objlist = new List<string>()
            {
                "sam1",
                "sam2",
                "sam3",
                "sam4",
                "sam5"
            };
            return objlist;
        }

        //--------------------------table------------------------------------------
        [Route("Emp/GetList")]
        public List<Emp> GetEmplist()
        {
            MyProjectEntities obj = new MyProjectEntities();
            var res = obj.Emps.ToList();
            return res;
        }


        //-----------------Stored Procedure---------------------------------------
        [Route("Emp/GetListAll")]
        public List<GetAlldeptData_Result> GetEmplistAll()    //table
        {
            MyProjectEntities objemp = new MyProjectEntities();
            var obje = objemp.GetAlldeptData().ToList();
            return obje;
        }

       
        [HttpPost]
        [Route("Emp/Save")]
        //to get response from ui side.if the action returns an HttpResponseMessage,web api converts the return value directly into HTTP response
        // Message,using the properties of the HttpResponseMessage objectto populate the response.otherwise if we use void then we will not know that it succeded or failed.

        public HttpResponseMessage SaveEmp(Emp obj)
        {

            /*previously in mvc we were taking value from model (in parameter) and then we pass that in database object
            but in web api parameter,we r passing table name instead of model because we are directly passing vlaue in dtabase so,we dont need 
            to create obj of db table.*/
            MyProjectEntities dbconn = new MyProjectEntities();
            if (obj.id == 0)
            {
                dbconn.Emps.Add(obj);
                dbconn.SaveChanges();
            }
            else
            {
                dbconn.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                dbconn.SaveChanges();
            }
            HttpResponseMessage resobj = new HttpResponseMessage(HttpStatusCode.OK);
            return resobj;
        }
        [Route("Emp/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            MyProjectEntities dbconn = new MyProjectEntities();
            var deleteitem = dbconn.Emps.Where(m => m.id == id).First();
            dbconn.Emps.Remove(deleteitem);
            dbconn.SaveChanges();
            HttpResponseMessage resobj = new HttpResponseMessage(HttpStatusCode.OK);
            return resobj;
        }
        [Route("Emp/Edit")]
        //datatype is table (emp) so,its directly returning the table values hence we dont need to create obj of table.
        public Emp Edit(int id)
        {
            MyProjectEntities dbconn = new MyProjectEntities();
            var editItem = dbconn.Emps.Where(m => m.id == id).First();
            return editItem;
        }
    }
}
