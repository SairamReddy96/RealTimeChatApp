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

            User user1 = new User("405", "Sairam", "Sairam96");
            User user2 = new User("408", "Sansita", "Sansita354");

            chatService.CreateChatRoom("ECE A");
            chatService.SendMessage("ECE A", user1, "Hello everyone!");
            chatService.SendMessage("ECE A", user2, "Hi Sairam!");

            chatService.DisplayAllMessages("ECE A");
            chatService.SearchMessages("Hello");

            Console.ReadKey();
        }
    }
}
