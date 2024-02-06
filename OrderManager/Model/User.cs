using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model
{
    internal class User
    {
        int userId;
        string userName;
        string userPassword;
        string userRole;

        // Constructors
        public User()
        {
            // Default constructor
        }

        public User(int userId, string userName, string userPassword, string userRole)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
        }

        // Getters and Setters
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
