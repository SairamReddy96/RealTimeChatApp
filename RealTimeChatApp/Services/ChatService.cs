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
                users[userName].LogIn();
                Console.WriteLine($"The user {userName} has been logged in successfully");
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }
        public void LogoutUser(string username)
        {
            if (!users.ContainsKey(username) || !users[username].isLoggedIn)
            {
                Console.WriteLine($"User '{username}' is not logged in.");
                return;
            }

            users[username].LogOut();
            Console.WriteLine($"User '{username}' logged out successfully.");
        }
        public void JoinChatRoom(string username, string roomName)
        {
            if(!users.ContainsKey(username) || !users[username].isLoggedIn)
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
        // this method broadcasts the messages for all the users in the specific room
        public void BroadcastMessage(string roomName, string messageText)
        {
            if(!chatRooms.ContainsKey(roomName)) {
                Console.WriteLine($"The chatroom with name '{roomName}' does not exist");
                return;
            }
            Console.WriteLine($"Broadcasting message to room '{roomName}' : '{messageText}'");
            foreach(var user in roomUsers[roomName])
            {
                Console.WriteLine($"[To '{user.UserName}'] : '{messageText}'");
            }
        }
        // used to send messages to a specific chatroom
        public void SendMessage(string roomName, string senderName, string messageText)
        {
            if(!chatRooms.TryGetValue(roomName, out var room))
            {
                Console.WriteLine("Chat room "+roomName+" doesn't exist");
                return;
            }
            if (!users.ContainsKey(senderName) || !users[senderName].isLoggedIn)
            {
                Console.WriteLine("The username "+senderName+" must be logged in to send a message");
                return;
            }
            var message = new Message(senderName, "Everyone", DateTime.Now, messageText);
            room.Messages.Add(message);
            BroadcastMessage(roomName, messageText);
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
        public void DisplayAllChatrooms()
        {
            if(chatRooms.Count == 0)
            {
                Console.WriteLine("No chat rooms exist");
                return;
            }
            foreach(var chatRooms in chatRooms.Values)
            {
                Console.WriteLine("Chat Room: "+chatRooms.RoomName);
                DisplayAllMessages(chatRooms.RoomName);
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
