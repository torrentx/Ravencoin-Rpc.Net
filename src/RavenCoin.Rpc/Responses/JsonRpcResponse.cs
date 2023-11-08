using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses
{
    public class JsonRpcResponse
    {
        public JsonRpcResponse(string id, JsonRpcError error)
        {
            Id = id;
            Error = error;
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("error")]
        public JsonRpcError Error { get; set; }
    }
}
