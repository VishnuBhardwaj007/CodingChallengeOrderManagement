using OrderManager.Model;
using OrderManager.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Repository
{
    internal class OrderManagementRepositoryImpl : IOrderManagementRepository
    {
        public string connectionString;
        //sql connection class
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;

        public OrderManagementRepositoryImpl()
        {
            connectionString = DBConnection.GetConnectionString();
            cmd = new SqlCommand();
        }


        //--------------------------------------------------------------------------------------------------------

       
        
        

        public bool CancelOrder(int userId, int orderId)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Delete from order where userId=@userId && orderId=@orderId";
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int addProductStatus = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return addProductStatus > 0;

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }


        }

        public bool CreateOrder(User user, List<Product> products,int quantity, string shippingAddress)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    foreach (Product product in products)
                    {

                        cmd.CommandText = "insert into Orders Values(@userId,@productId,@orderDate,@totalPrice,@shippingAddress";
                        cmd.Parameters.AddWithValue("@userId", user.UserId);
                        cmd.Parameters.AddWithValue("@productId", product.ProductId);
                        cmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@totalPrice", (product.ProductPrice*quantity));
                        cmd.Parameters.AddWithValue("@shippingAddress", shippingAddress);

                    }

                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int addOrderstatus = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return addOrderstatus > 0;

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }




        }

        //--------------------------------------------------------Is USer ID Present in Order-----------------------
        public bool IsUserIdPresentInOrders(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;

                        cmd.CommandText = "SELECT COUNT(*) FROM Orders WHERE userId = @userId";
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if userId is present in Orders: {ex.Message}");
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------

        public bool CreateProduct(User user, Product product)
        {
            #region Code 1
            try
            {
                if (user.UserRole == "Admin")
                {
                    using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                    {

                        cmd.CommandText = "insert into Product values(@productId,@productName,@productPrice,@productDesc,@stockQuantity)";
                        cmd.Parameters.AddWithValue("@productId", product.ProductId);
                        cmd.Parameters.AddWithValue("@productName", product.ProductName);
                        cmd.Parameters.AddWithValue("@productPrice", product.ProductPrice);
                        cmd.Parameters.AddWithValue("@productDesc", product.ProductDesc);
                        cmd.Parameters.AddWithValue("@stockQuantity", product.ProductQuantityInStock);

                        cmd.Connection = sqlconnection;
                        sqlconnection.Open();
                        int addProductStatus = cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        return addProductStatus > 0;

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product: {ex.Message}");
                return false;
            }
            #endregion
            {
                try
                {
                    if (user.UserRole == "Admin")
                    {
                        using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "INSERT INTO Product VALUES(@productId, @productName, @productPrice, @productDesc, @stockQuantity)";
                                cmd.Parameters.AddWithValue("@productId", product.ProductId);
                                cmd.Parameters.AddWithValue("@productName", product.ProductName);
                                cmd.Parameters.AddWithValue("@productPrice", product.ProductPrice);
                                cmd.Parameters.AddWithValue("@productDesc", product.ProductDesc);
                                cmd.Parameters.AddWithValue("@stockQuantity", product.ProductQuantityInStock);

                                cmd.Connection = sqlconnection;
                                sqlconnection.Open();
                                int addProductStatus = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();
                                return addProductStatus > 0;
                            }
                        }
                    }

                    // Default return statement if the condition is not met
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating product: {ex.Message}");
                    return false;
                }
            }
        }


        public bool CreateUser(User user)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {

                    cmd.CommandText = "insert into Customer values(@userId,@userName,@userPassword,@userRole)";
                    cmd.Parameters.AddWithValue("@userId", user.UserId);
                    cmd.Parameters.AddWithValue("@userName", user.UserName);
                    cmd.Parameters.AddWithValue("@userPassword", user.UserPassword);
                    cmd.Parameters.AddWithValue("@userRole", user.UserRole);

                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int addCustomerStatus = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return addCustomerStatus > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating customer: {ex.Message}");
                return false;
            }


        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Product";
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductId = (int)reader["productId"];
                        product.ProductName = (string)reader["productName"];
                        product.ProductDesc = (string)reader["productDesc"];
                        product.ProductPrice = (double)reader["productPrice"];
                        product.ProductQuantityInStock = (int)reader["productPrice"];
                        product.Type = (string)reader["type"];
                        products.Add(product);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
            
        }

        public List<string> GetOrderByUser(User user)
        {
            List<string> products = new List<string>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {



                    cmd.CommandText = "SELECT p.productName from product p join order o on o.productId=p.productId where userId=@UserId";
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader["productName"].ToString();

                        products.Add(productName);
                    }
                    cmd.Parameters.Clear();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting orders by customer: {ex.Message}");
            }

            return products;
        }

        public bool CreateOrder(User user, List<Product> products)
        {
            throw new NotImplementedException();
        }
    }


}

