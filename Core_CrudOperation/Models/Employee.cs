using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_Core.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }    //bydefault  1,1
        [Required]    //i.e.,not null
        public string Name { get; set; }
        [Required]
        public int age { get; set; }
        public string email { get; set; }
        public int sal { get; set; }
        public string dept { get; set; }
        public string address { get; set; }
        public int zipcode { get; set; }
    }
}
