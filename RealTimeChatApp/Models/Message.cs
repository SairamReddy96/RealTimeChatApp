using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Models
{
    public class Message
    {
        public string Sender {  get; set; }
        public string Receiver { get; set; }
        public DateTime TimeStamp { get; set; }
        public string MessageText { get; set; }
        public Message(string sender, string receiver, DateTime timeStamp, string messageText)
        {
            Sender = sender;
            Receiver = receiver;
            TimeStamp = timeStamp;
            MessageText = messageText;
        }
    }
}
