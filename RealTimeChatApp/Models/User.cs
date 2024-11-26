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
        public bool isLoogedIn { get; set; }
        public User(string ID, string userName, string password)
        {
            this.ID = ID;
            UserName = userName;
            Password = password;
            isLoogedIn = false;
        }
    }
}
