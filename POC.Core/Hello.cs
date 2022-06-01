

using Newtonsoft.Json;

namespace POC.Core
{
    public class Hello : Request
    {
        [JsonConstructor]
        public Hello(OpCode op) : base(op)
        {

        }
    }
}
