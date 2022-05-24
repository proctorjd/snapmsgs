
using WebSocketSharp;
using WebSocketSharp.Server;

namespace POC_Server
{
    public class Chat: WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Console.WriteLine($"Client Connected: {ID}");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine($"Client Disconnected: {ID}");
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine($"Error: {e.Message}");
            Console.WriteLine($"Exception: {e.Exception}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Server received message from: {ID}: {e.Data}");
        }
    }
}
