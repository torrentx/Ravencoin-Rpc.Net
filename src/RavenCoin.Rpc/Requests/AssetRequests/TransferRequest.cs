using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class TransferRequest : JsonRpcRequest
    {
        public TransferRequest()
        {
            Id = 1;
            Method = RpcMethods.transfer.ToString();
        }

        [JsonPropertyName("asset_name")]
        public string? AssetName { get; set; }
        [JsonPropertyName("qty")]
        public decimal? Quantity { get; set; }
        [JsonPropertyName("to_address")]
        public string? ToAddress { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("expire_time")]
        public long? ExpireTime { get; set;  }
        [JsonPropertyName("change_address")]
        public string? ChangeAddress { get; set;  }
        [JsonPropertyName("asset_change_address")]
        public string? AssetChangeAddress { get; set; }

        internal override void FlushParameters()
        {
            Parameters = new List<object>();
            if (AssetName != null)
            {
                Parameters.Add(AssetName);
            }
            if(Quantity != null)
            {
                Parameters.Add(Quantity);
            }
            if (ToAddress != null)
            {
                Parameters.Add(ToAddress);
            }
            if (Message != null)
            {
                Parameters.Add(Message);
            }
            if (ExpireTime != null)
            {
                Parameters.Add(ExpireTime);
            }
            if(!string.IsNullOrEmpty(ChangeAddress))
            {
                Parameters.Add(ChangeAddress);
            }
            if(!string.IsNullOrEmpty(AssetChangeAddress))
            {
                Parameters.Add(AssetChangeAddress);
            }
            
        }
    }
}
