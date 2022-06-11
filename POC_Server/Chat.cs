
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

            var output = new StringBuilder()
            .AppendFormat("{0} - {1}:", DateTime.UtcNow.ToString("mm: hh tt"), ID).AppendLine()
            .AppendLine(e.Data);

            ParseJson(e.Data);
            //Sessions.Broadcast(output.ToString());
            ///Sessions.Broadcast(e.Data);

        }

        private string Header ()
        {
            return String.Format("{0} - {1}:", DateTime.UtcNow.ToString("mm: hh tt"), ID);
        }

        private void Broadcast()
        {

        }

        private void ParseJson(string json)
        {
            var request = JsonConvert.DeserializeObject<Request>(json);

            switch (request.Op)
            {
                case OpCode.Hello:
                    //var helloRequest = JsonConvert.DeserializeObject<Hello>(json);


                    var output = new StringBuilder()
                    .AppendFormat("There are so many users logged in!", Sessions.Count).AppendLine()
                    .AppendLine();

                     foreach(var session in Sessions.Sessions)
                     {
                        if (session.ID == ID)
                        continue;

                        output.AppendLine(session.ID);
                     }

                      Send(output.ToString());

                    Sessions.Broadcast($"User joined servier ID: {ID}");

                    break;
                default:
                    break;

            }

        }
    }
}
