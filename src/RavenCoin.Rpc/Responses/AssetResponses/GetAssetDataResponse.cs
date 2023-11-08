using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.AssetResponses
{
    public class GetAssetDataResponse : JsonRpcResponse
    {

        public GetAssetDataResponse(string id, JsonRpcError error) : base (id,error)
        {
        }

        [JsonPropertyName("result")]
        public GetAssetDataResponseResult? Result { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new ();
            if (Result != null) {
                sb.Append($"Asset Name: {Result.AssetName}");
                sb.Append(Environment.NewLine);
                sb.Append($"Amount: {Result.Amount}");
                sb.Append(Environment.NewLine);
                sb.Append($"Units: {Result.Units}");
                sb.Append(Environment.NewLine);
                sb.Append($"Reissuable " + (Result.Reissuable == 1)) ;
                sb.Append(Environment.NewLine);
                sb.Append($"Has IPFS?: " + (Result.HasIpfs == 1));
                sb.Append(Environment.NewLine);
                sb.Append($"IPFS: {Result.Ipfs}");
            }
            else
            {
                sb.Append("Empty Result check error message.");
            }

            return sb.ToString();
        }
    }

    public class GetAssetDataResponseResult
    {
        public GetAssetDataResponseResult() { }
        [JsonPropertyName("name")]
        public string? AssetName { get; set; }
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("units")]
        public decimal Units { get; set; }
        [JsonPropertyName("reissuable")]
        public int Reissuable { get; set; }
        [JsonPropertyName("has_ipfs")]
        public int HasIpfs { get; set; }
        [JsonPropertyName("ipfs_hash")]
        public string? Ipfs { get; set; }
    }
}
