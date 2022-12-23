using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komplettering_Labb3.DataModels.Products
{
    public class Item : Product
    {
        public Item(string name, float price) : base(name, price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
