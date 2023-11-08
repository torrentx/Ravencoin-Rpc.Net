using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    internal class AddTagToAddressRequest : JsonRpcRequest
    {
        public AddTagToAddressRequest()
        {
            Id = 1;
            Method = RpcMethods.addtagtoaddress.ToString();
            Parameters = new List<object>();
        }
        [JsonPropertyName("tag_name")]
        string? TagName { get; set; }
        [JsonPropertyName("to_address")]
        string? ToAddress { get; set; }
        [JsonPropertyName("change_address")]
        string? ChangeAddress { get; set; }
        [JsonPropertyName("asset_data")]
        string? AssetData { get; set; }

        internal override void FlushParameters()
        {
            Parameters = new List<object>();
            if (TagName != null)
                Parameters.Add(TagName);
            if (ToAddress != null)
                Parameters.Add(ToAddress);
            if (ChangeAddress != null)
                Parameters.Add(ChangeAddress);
            if (!string.IsNullOrWhiteSpace(AssetData))
                Parameters.Add(AssetData);
        }
    }
}