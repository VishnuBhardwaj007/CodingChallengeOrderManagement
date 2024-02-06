using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model
{
    internal class Electronic:Product
    {
        string brand;
        int warrantyPeriod;

        // Constructors
        public Electronic()
        {
            // Default constructor
        }

        public Electronic(int productId, string productName, string description, double price, int quantityInStock, string type, string brand, int warrantyPeriod)
            : base(productId, productName, description, price, quantityInStock, type)
        {
            this.brand = brand;
            this.warrantyPeriod = warrantyPeriod;
        }

        // Additional getters and setters for Electronics attributes
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public int WarrantyPeriod
        {
            get { return warrantyPeriod; }
            set { warrantyPeriod = value; }
        }

    }
}
