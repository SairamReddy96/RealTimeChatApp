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
        public List<Message> Messages { get; set; } 
        public User(string ID, string Name, string UserName)
        {
            this.ID = ID;
            this.Name = Name;
            this.UserName = UserName;
            Messages = new List<Message>();
        }
    }
}
