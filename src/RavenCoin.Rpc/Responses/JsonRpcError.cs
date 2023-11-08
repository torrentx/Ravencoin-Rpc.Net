using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses
{
    public class JsonRpcError
    {
        [JsonPropertyName("code")]
        public RpcErrorCode Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
