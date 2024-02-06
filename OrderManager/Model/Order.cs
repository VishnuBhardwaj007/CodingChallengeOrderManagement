using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model
{
    internal class Order
    {
        private int orderId;
        private int userId;
        private int productId;
        private DateTime orderDate;
        private decimal totalPrice;
        private string shippingAddress;

        // Default constructor
        public Order()
        {
        }

        // Parameterized constructor
        public Order(int orderId, int userId, int productId, DateTime orderDate, decimal totalPrice, string shippingAddress)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.productId = productId;
            this.orderDate = orderDate;
            this.totalPrice = totalPrice;
            this.shippingAddress = shippingAddress;
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public string ShippingAddress
        {
            get { return shippingAddress; }
            set { shippingAddress = value; }
        }
    }
}
