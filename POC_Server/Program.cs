using System;
using WebSocketSharp.Server;

namespace POC_Server
{
    class Program
    {
        public static readonly WebSocketServer ServerSocket = new("ws://localhost:9876");
      

        //Getting server online
        static void Main(string[] args)
        {
            ServerSocket.Start();
            Console.WriteLine("Server started. Press any key to stop the server.");
            Console.ReadKey();
            ServerSocket.Stop();

        }

    }



}