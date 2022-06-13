

using Newtonsoft.Json;

namespace POC.Core
{
    public class Message: Request
    {
        [JsonProperty]  

        public string Text { get; private set; }

        [JsonConstructor]

        public Message(OpCode op, string text) : base(op)
            => Text = text;
        
    }
}
