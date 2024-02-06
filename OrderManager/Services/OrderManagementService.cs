using OrderManager.Exceptions;
using OrderManager.Model;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Services
{
    internal class OrderManagementService:OrderManagementRepositoryImpl,IOrderMangementService
    {
        readonly IOrderManagementRepository _OrderManagement;

            public OrderManagementService()
        {
            _OrderManagement = new OrderManagementRepositoryImpl();
        }

        public void CancelOrder()
        {

            try
            {
                Console.WriteLine("Enter User Id");
                int userId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Order ID");
                int orderId = int.Parse(Console.ReadLine());

                if (IsUserIdPresentInOrders(userId))
                {
                    // Implement your order cancellation logic here

                    Console.WriteLine($"Order {orderId} for User {userId} canceled successfully.");
                }
                else
                {
                    throw new UserNotFoundException($"User with ID {userId} not found in Orders.");
                }
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine($"Error canceling order: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error canceling order: {ex.Message}");
            }



        }

        public void CreateOrder()
        {
            List<Product> products = new List<Product>();   
            Product product=new Product();
            User user = new User();

            Console.WriteLine("Enter User Id::");
            user.UserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter User Name ::");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Enter User PassWord::");
            user.UserPassword = Console.ReadLine();
            Console.WriteLine("Enter User Role ::");
            user.UserRole = Console.ReadLine();

            Console.WriteLine("Enter Product ID");
            product.ProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Name");
            product.ProductName = Console.ReadLine();

            Console.WriteLine("Enter Product Discription");
            product.ProductDesc = Console.ReadLine();

            Console.WriteLine("Enter Product Price");
            product.ProductPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Quantity In Stock");
            product.ProductQuantityInStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Type");
            product.Type = Console.ReadLine();

            Console.WriteLine("Enter Product quantity");
            int quantity = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();



            products.Add(product);

            bool productStatus = _OrderManagement.CreateOrder(user, products, quantity, address);
            if (productStatus)
            {
                Console.WriteLine("Created Successfully");
            }

            else
            {
                Console.WriteLine("failed");
            }

        }

        public void CreateProduct()
        {
            User user = new User();
            Product product = new Product();
            Console.WriteLine("Enter User Role:: ");
            user.UserRole = Console.ReadLine();

            Console.WriteLine("Enter Product ID");
            product.ProductId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Name");
            product.ProductName=Console.ReadLine();

            Console.WriteLine("Enter Product Discription");
            product.ProductDesc = Console.ReadLine();

            Console.WriteLine("Enter Product Price");
            product.ProductPrice=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Quantity In Stock");
            product.ProductQuantityInStock=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Type");
            product.Type = Console.ReadLine();

            bool createProductStatus = _OrderManagement.CreateProduct(user,product);

            if (createProductStatus)
            {
                Console.WriteLine("Product created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create product.");
            }


        }

        public void CreateUser()
        {
            User user = new User();

            Console.WriteLine("Enter User Id::");
            user.UserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter User Name ::");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Enter User PassWord::");
            user.UserPassword = Console.ReadLine();
            Console.WriteLine("Enter User Role ::");
            user.UserRole = Console.ReadLine();


            bool createUserStatus = _OrderManagement.CreateUser(user);

            if (createUserStatus)
            {
                Console.WriteLine("Customer created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create customer.");
            }
        }

        public void GetAllProducts()
        {
            List<Product> productList = _OrderManagement.GetAllProducts();
            foreach (Product product in productList)
            {
                Console.WriteLine(product);
            }
        }

        public void GetOrderByUser()
        {
            try
            {
                List<string> products = new List<string>();
                User user = new User();

                Console.WriteLine("Enter User Id::");
                user.UserId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter User Name ::");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter User PassWord::");
                user.UserPassword = Console.ReadLine();
                Console.WriteLine("Enter User Role ::");
                user.UserRole = Console.ReadLine();


                products = _OrderManagement.GetOrderByUser(user);
                int i = 1;
                foreach (string product in products)
                {
                    Console.WriteLine($"Products for User are:{i}.{product}");
                    i++;
                }
            } catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        

        
    }
}
