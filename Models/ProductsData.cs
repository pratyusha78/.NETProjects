using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class ProductsData
    {
        public IEnumerable<Products> ProductsList
        {
            get
            {
                List<Products> product = new List<Products>() { new Products{ProductId=1,Name="Reliance",Price=2662.22},
                    new Products{ProductId=2,Name="tata",Price=37873.33} };
                return product;
            }
        }
    }
}