using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model
{
    internal class Clothing:Product
    {
        string size;
        string color;

        // Constructors
        public Clothing()
        {
            // Default constructor
        }

        public Clothing(int productId, string productName, string description, double price, int quantityInStock, string type, string size, string color)
            : base(productId, productName, description, price, quantityInStock, type)
        {
            this.size = size;
            this.color = color;
        }

        // Additional getters and setters for Clothing attributes
        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

    }
}
