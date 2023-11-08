using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.BlockchainResponses
{
    public class GetBlockCountResponse : JsonRpcResponse
    {
        public GetBlockCountResponse(string id, JsonRpcError error) : base(id, error) { }
        [JsonPropertyName("result")]
        public uint Result { get; set; }
    }
}
