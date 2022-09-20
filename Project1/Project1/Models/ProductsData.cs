using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class ProductsData
    {
        public IEnumerable<Product> ProductsList
        {
            get
            {
                List<Product> p = new List<Product>()

                { new Product{ProductId=1,Name="Reliance",Price=34642.34},new Product{ProductId=2,Name="Tata",Price=7024242.22} };

               return p;
            }
 
        }
    }
}