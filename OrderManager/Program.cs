using OrderManager.Repository;
using OrderManager.Services;

namespace OrderManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrderMangementService orderManagement = new OrderManagementService();



            while (true)
            {

                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Place an Order");
                Console.WriteLine("5. Cancel Order");
                Console.WriteLine("6. Get Order By User");
                Console.WriteLine("7. To Log Out");

                string userInput = Console.ReadLine();

                Console.Clear();
                switch (userInput)
                {
                   
                    case "1":
                        
                        orderManagement.CreateUser();
                        break;
                    case "2":
                        
                        orderManagement.CreateProduct();
                        break;
                    case "3":
                        
                        orderManagement.GetAllProducts();
                        break;
                    case "4":
                        
                        orderManagement.CreateOrder();
                        break;
                    case "5":
                        
                        orderManagement.CancelOrder();
                        break;
                    case "6":
                      
                        orderManagement.GetOrderByUser();
                        break;
                    case "7":
                        // Exit the application
                        Console.WriteLine("Exiting....");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }

            }
        }
    }
}

