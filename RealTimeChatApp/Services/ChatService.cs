using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Models;

namespace RealTimeChatApp.Services
{
    public class ChatService
    {
        private Dictionary<string, ChatRoom> chatRooms;

        public ChatService()
        {
            chatRooms = new Dictionary<string, ChatRoom>();
        }

        public void CreateChatRoom(string roomName)
        {
            if(chatRooms.ContainsKey(roomName))
            {
                Console.WriteLine("This room already exists!");
                return;
            }

            var room = new ChatRoom(roomName);
            chatRooms.Add(roomName, room);
            Console.WriteLine($"The chatroom with name '{roomName}' has been created");
        }
        // used to send messages to a specific chatroom
        public void SendMessage(string roomName, User sender, string messageText)
        {
            if(!chatRooms.TryGetValue(roomName, out var room))
            {
                Console.WriteLine("Chat room "+roomName+" doesn't exist");
                return;
            }
            var message = new Message(sender.UserName, "Everyone", DateTime.Now, messageText);
            room.Messages.Add(message);
            Console.WriteLine($"Message sent to room {roomName} : [{sender.UserName}] {messageText}");
        }
        // used to display all the messages of specified chatroom
        public void DisplayAllMessages(string roomName)
        {
            if(!chatRooms.TryGetValue(roomName, out var chatRoom))
            {
                Console.WriteLine("Chat room " + roomName + " doesn't exist");
                return;
            }

            Console.WriteLine($"Messages in room '{roomName}':");
            foreach(var message in chatRoom.Messages)
            {
                Console.WriteLine($"[{message.TimeStamp}] {message.Sender}: {message.MessageText}");
            }
        }
        // to search messages containing a specific keyword across all ChatRooms
        public void SearchMessages(string keyword)
        {
            var matchingMessages = new List<Message>();

            foreach(var room in chatRooms.Values)
            {
                matchingMessages.AddRange(room.Messages.FindAll(m => m.MessageText.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
            }

            if(matchingMessages.Count > 0)
            {
                Console.WriteLine("Messages matching keywords '"+keyword+"'");
                foreach(var message in matchingMessages)
                {
                    Console.WriteLine($"[{message.TimeStamp}] {message.Sender} : {message.MessageText}");
                }
            }

            else
            {
                Console.WriteLine("No messages matching with the keyword "+keyword+" is found");
            }
        }   

    }
}
