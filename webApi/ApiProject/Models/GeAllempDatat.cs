using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiProject.Models
{
    public class GeAllempDatat
    {
       
        public string address { get; set; }
        public Nullable<int> zipcode { get; set; }
        public string Name { get; set; }
        public Nullable<int> age { get; set; }
        public string Email { get; set; }
        public Nullable<int> sal { get; set; }
        public string dept { get; set; }
    }
}