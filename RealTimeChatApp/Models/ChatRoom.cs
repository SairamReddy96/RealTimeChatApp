using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Models
{
    public class ChatRoom
    {
        public string RoomName { get; set; }
        public List<Message> Messages { get; set; }
        public ChatRoom(string RoomName)
        {
            this.RoomName = RoomName;
            Messages = new List<Message>();
        }
    }
}
