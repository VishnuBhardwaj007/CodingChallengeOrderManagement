using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Services
{
    internal interface IOrderMangementService
    {
        void CreateUser();

        void CreateProduct();

        void GetAllProducts();

        void GetOrderByUser();

        void CancelOrder();
        void CreateOrder();

     }
}
