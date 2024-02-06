using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model
{
    internal class Product
    {
        int productId;
        string productName;
        string productDesc;
        double productPrice;
        int productQuantityInStock;
        string type;

        // Constructors
        public Product()
        {
            // Default constructor
        }

        public Product(int productId, string productName, string description, double price, int quantityInStock, string type)
        {
            this.productId = productId;
            this.productName = productName;
            productDesc = description;
            productPrice = price;
            productQuantityInStock = quantityInStock;
            this.type = type;
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string ProductDesc
        {
            get { return productDesc; }
            set { productDesc = value; }
        }

        public double ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }

        public int ProductQuantityInStock
        {
            get { return ProductQuantityInStock; }
            set { ProductQuantityInStock = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
