using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.AssetResponses
{
    public class ListAssetResponse : JsonRpcResponse
    {
        public ListAssetResponse(string id, JsonRpcError error) : base (id,error)
        {
            Result = new Dictionary<string, decimal>();
        }

        [JsonPropertyName("result")]
        public Dictionary<string, decimal> Result { get; set; }

        public List<Asset> Assets
        {
            get
            {
                return Result.Select(m => new Asset(m.Key, m.Value)).ToList();
            }
        }
    }

    public class Asset
    {
        public Asset(string name, decimal value)
        {
            AssetName = name;
            AssetValue = value;
        }
        public string AssetName { get; set; }
        public decimal AssetValue { get; set; }
    }
}
