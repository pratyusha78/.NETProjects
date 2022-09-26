using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class EmpClass
    {
        
        public int id { get; set; }
       
        public string Name { get; set; }
     
        public string Email { get; set; }
       
        public string Mobile { get; set; }
        public string Company { get; set; }
        public string Dept { get; set; }
        public int? Salary { get; set; }
    }
}