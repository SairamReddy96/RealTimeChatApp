using RealTimeChatApp.Models;
using RealTimeChatApp.Services;

namespace RealTimeChatApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the Real-Time Chat Application!");
            ChatService chatService = new ChatService();
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Login User");
                Console.WriteLine("3. Log Out User");
                Console.WriteLine("4. Create Chatroom");
                Console.WriteLine("5. Join Chatroom");
                Console.WriteLine("6. Send Message");
                Console.WriteLine("7. Search Messages");
                Console.WriteLine("8. Display Chat Rooms");
                Console.WriteLine("9. Exit the application");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.Write("Enter the user name: ");
                        string userName = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        chatService.RegisterUser(userName, password);
                        break;

                    case "2":
                        Console.Write("Enter the user name: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string loginPassword = Console.ReadLine();
                        chatService.LoginUser(loginUsername, loginPassword);
                        break;

                    case "3":
                        Console.Write("Enter the user name: ");
                        string logoutUsername = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string logoutPassword = Console.ReadLine();
                        chatService.LogoutUser(logoutUsername);
                        break;

                    case "4":
                        Console.Write("Enter the Chat Room name: ");
                        string roomName = Console.ReadLine();
                        chatService.CreateChatRoom(roomName);
                        break;

                    case "5":
                        Console.Write("Enter the user name: ");
                        string joinUsername = Console.ReadLine();
                        Console.Write("Enter the room name: ");
                        string joinRoomname = Console.ReadLine();
                        chatService.JoinChatRoom(joinUsername, joinRoomname);
                        break;

                    case "6":
                        Console.Write("Enter chat room name: ");
                        string existingRoomName = Console.ReadLine();
                        Console.Write("Enter your username: ");
                        string sender = Console.ReadLine();
                        Console.Write("Enter your message: ");
                        string message = Console.ReadLine();
                        chatService.SendMessage(existingRoomName, sender, message);
                        break;

                    case "7":
                        Console.Write("Enter the keyword: ");
                        string keyword = Console.ReadLine();
                        chatService.SearchMessages(keyword);
                        break;

                    case "8":
                        chatService.DisplayAllChatrooms();
                        break;

                    case "9":
                        exit = true;
                        Console.WriteLine("Exiting the application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, Please try again.");
                        break;
                }
            }
        }
    }
}
