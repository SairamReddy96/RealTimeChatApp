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
        private Dictionary<string, User> users;
        private Dictionary<string, List<User>> roomUsers;
        public ChatService()
        {
            chatRooms = new Dictionary<string, ChatRoom>();
            users = new Dictionary<string, User>();
            roomUsers = new Dictionary<string, List<User>>();
        }
        public void RegisterUser(string username, string password)
        {
            if(users.Count != 0 && users.ContainsKey(username))
            {
                Console.WriteLine($"The username {username} already exists");
                return;
            }
            var user = new User(Guid.NewGuid().ToString(), username, password);
            users.Add(username, user);
            Console.WriteLine($"Username {username} has been registered succesfully");
        }
        public void LoginUser(string userName, string passWord)
        {
            if(users.ContainsKey(userName) && users[userName].Password == passWord)
            {
                users[userName].isLoogedIn = true;
                Console.WriteLine($"The user {userName} has been logged in successfully");
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }
        public void JoinChatRoom(string username, string roomName)
        {
            if(!users.ContainsKey(username) || !users[username].isLoogedIn)
            {
                Console.WriteLine("The username has not logged in or does not exist!");
                return;
            }
            if(!chatRooms.ContainsKey(roomName))
            {
                Console.WriteLine("The chatroom "+roomName+" does not exist");
                return;
            }
            var user = users[username];
            roomUsers[roomName].Add(user);
            Console.WriteLine($"The user {username} has been added to the {roomName} room");

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
            roomUsers.Add(roomName, new List<User>());
            Console.WriteLine($"The chatroom with name '{roomName}' has been created");
        }
        // used to send messages to a specific chatroom
        public void SendMessage(string roomName, string senderName, string messageText)
        {
            if(!chatRooms.TryGetValue(roomName, out var room))
            {
                Console.WriteLine("Chat room "+roomName+" doesn't exist");
                return;
            }
            if (!users.ContainsKey(senderName) || !users[senderName].isLoogedIn)
            {
                Console.WriteLine("The username "+senderName+" must be logged in to send a message");
            }
            var message = new Message(senderName, "Everyone", DateTime.Now, messageText);
            room.Messages.Add(message);
            Console.WriteLine($"Message sent to room {roomName} : [{senderName}] {messageText}");
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
