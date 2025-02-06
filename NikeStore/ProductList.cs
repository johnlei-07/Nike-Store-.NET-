using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeStore
{
    internal class ProductList
    {
        public int Price;
        public string ProductName;
        public string Category;

        public override string ToString()
        {
            return ProductName;
        }
    }
}
