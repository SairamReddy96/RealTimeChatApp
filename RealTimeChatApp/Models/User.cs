using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isLoggedIn { get; set; }
        public User(string ID, string userName, string password)
        {
            this.ID = ID;
            UserName = userName;
            Password = password;
            isLoggedIn = false;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
        public bool VerifyPassword(string password)
        {
            return this.Password == password;
        }
        public void LogIn()
        {
            isLoggedIn = true;
        }
        public void LogOut()
        {
            isLoggedIn = false;
        }
    }
}
