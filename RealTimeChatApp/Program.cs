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

            chatService.RegisterUser("Sairam", "Sairam123");
            chatService.RegisterUser("Sansita", "Sansita456");
            chatService.RegisterUser("bob", "bob28");
            Console.WriteLine();

            chatService.LoginUser("Sairam", "Sairam123");
            chatService.LoginUser("Sansita", "Sansita456");
            chatService.LoginUser("bob", "bob28");
            Console.WriteLine();

            chatService.CreateChatRoom("ECE A");
            chatService.CreateChatRoom("VNR Hostel");
            Console.WriteLine();

            chatService.JoinChatRoom("Sairam", "ECE A");
            chatService.JoinChatRoom("Sairam", "VNR Hostel");
            chatService.JoinChatRoom("Sansita", "ECE A");
            chatService.JoinChatRoom("bob", "VNR Hostel");
            Console.WriteLine();

            chatService.SendMessage("ECE A", "Sairam", "Hello ECE");
            chatService.SendMessage("ECE A", "Sansita", "Hello Sairam!");
            Console.WriteLine();

            chatService.SendMessage("VNR Hostel", "bob", "Hello Hostel mates");
            chatService.SendMessage("VNR Hostel", "Sairam", "Hello!");
            Console.WriteLine();

            chatService.DisplayAllMessages("ECE A");
            chatService.DisplayAllMessages("VNR Hostel");
            Console.WriteLine();

            chatService.SearchMessages("Hello");
            Console.ReadKey();
        }
    }
}
