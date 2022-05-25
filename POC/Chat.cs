using System;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;


namespace POC
{
    public partial class Chat : Form
    {
        private readonly WebSocket _socket = new("ws://localhost:9876");
     
        public Chat()
        {
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            _socket.OnOpen += Socket_OnOpen;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            _socket.OnClose += Socket_OnClose;
            _socket.OnError += Socket_OnError;
            _socket.OnMessage += Socket_OnMessage;

            InitializeComponent();
        }

        private void Socket_OnMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            var output = new StringBuilder()
                .AppendLine("Message received: {e.Data}");
            rtbOutput.Text = output.ToString(); 

           
        }

        private void Socket_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }

        private void Socket_OnClose(object sender, EventArgs e)

        {
            rtbOutput.AppendText("Disconnected from Server." + Environment.NewLine);
            btnConnect.Text = "Connect";
            txtSendMessage.Enabled = false;
            btnSend.Enabled = false;
        }

        private void Socket_OnOpen(object sender, EventArgs e)

        {
            rtbOutput.AppendText("Connected to Server." + Environment.NewLine);
            btnConnect.Text = "Disconnect";
            txtSendMessage.Enabled = true;
            btnSend.Enabled = true;
        }

        private void Chat_Load (object sender, EventArgs e)

        {

        }
    }
}