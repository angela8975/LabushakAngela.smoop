using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ExpPerProduct { get; set; }


        public Product(string name, int quantity, int expPerProduct)
        {
            Name = name;
            Quantity = quantity;
            ExpPerProduct = expPerProduct;

        }
    }
}
