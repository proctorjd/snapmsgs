namespace POC
{
    partial class Chat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(21, 12);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(745, 494);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Enabled = false;
            this.txtSendMessage.Location = new System.Drawing.Point(12, 512);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.PlaceholderText = "Write your message...";
            this.txtSendMessage.Size = new System.Drawing.Size(537, 27);
            this.txtSendMessage.TabIndex = 1;
         
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(555, 512);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(106, 29);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(667, 512);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(99, 27);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 554);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.rtbOutput);
            this.Name = "Chat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private RichTextBox rtbOutput;
        private TextBox txtSendMessage;
        private Button btnSend;
        private Button btnConnect;
    }
}