using OrderManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Repository
{
    internal interface IOrderManagementRepository
    {

        bool CreateUser(User user);
        bool CreateProduct(User user, Product product);
        List<Product> GetAllProducts();

        bool CreateOrder(User user,List<Product> products, int quantity, string shippingAddress);
        bool CancelOrder(int userId, int OrderId);
        List<string> GetOrderByUser(User user);
    }
}
