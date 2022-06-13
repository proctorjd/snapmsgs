
using Newtonsoft.Json;
using POC.Core;
using System;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace POC_Server
{
    public class Chat: WebSocketBehavior

    {
        private string Header(string id = null) => String.Format("{0} - {1}:", DateTime.UtcNow.ToString("mm: hh tt"), id ?? ID);

        protected override void OnOpen() => Console.WriteLine($"Client Connected: {ID}");

        protected override void OnClose(CloseEventArgs e) => Console.WriteLine($"Client Disconnected: {ID}");

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine($"Error: {e.Message}");
            Console.WriteLine($"Exception: {e.Exception}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Server received message from: {ID}: {e.Data}");

            //var output = new StringBuilder()
            //.AppendFormat("{0} - {1}:", DateTime.UtcNow.ToString("mm: hh tt"), ID).AppendLine()
            //.AppendLine(e.Data);

            ParseJson(e.Data);
            //Sessions.Broadcast(output.ToString());
            ///Sessions.Broadcast(e.Data);

        }

        private void ParseJson(string json)
        {
            var request = JsonConvert.DeserializeObject<Request>(json);

            switch (request.Op)
            {
                case OpCode.Hello:
                    //var helloRequest = JsonConvert.DeserializeObject<Hello>(json);


                    var output = new StringBuilder()
                    .AppendLine(Header("Server"))
                    .AppendFormat("There are so many users logged in!", Sessions.Count).AppendLine()
                    .AppendLine();

                     foreach(var session in Sessions.Sessions)
                     {
                        if (session.ID == ID)
                        continue;

                        output.AppendLine(session.ID);
                     }

                      Send(output.ToString());

                    Sessions.Broadcast($"{Header("Server") + Environment.NewLine} User joined servier ID: {ID}");

                    break;
                // default:
                // Send(JsonConvert.SerializeObject(new Message(OpCode.Message, Header("Server") + "Message Received: " + json)));
                //break;

                case OpCode.Message:
                    var msg = JsonConvert.DeserializeObject<Message>(json);
                    Sessions.Broadcast(Header() + Environment.NewLine + msg.Text);
                    break;
            }

        }
    }
}
