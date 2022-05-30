

using Newtonsoft.Json;

namespace POC.Core
{
    public abstract class Request
    {
        [JsonProperty]
        public OpCode Op { get; private set; }

        protected Request(OpCode op)
            => Op = op;
    }
}
