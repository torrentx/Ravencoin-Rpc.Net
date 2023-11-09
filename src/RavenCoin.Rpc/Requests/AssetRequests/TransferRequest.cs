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
        /// <summary>
        /// Transfers a quantity of an owned asset to a given address
        /// </summary>
        public TransferRequest()
        {
            Id = 1;
            Method = RpcMethods.transfer.ToString();
            AssetName = string.Empty;
            Quantity = 0;
            ToAddress = string.Empty;
        }

        /// <summary>
        /// Name of Asset
        /// </summary>
        [JsonPropertyName("asset_name")]
        public string AssetName { get; set; }
        /// <summary>
        /// Number of asses you want to send to the address
        /// </summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Address to Send the Asset to
        /// </summary>
        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; }

        /// <summary>
        /// (optional)
        /// Once RIP5 is voted in ipfs hash or txid hash to send along with the transfer
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        /// <summary>
        /// (optional)
        /// UTC timestamp of when the message expires
        /// </summary>
        [JsonPropertyName("expire_time")]
        public long? ExpireTime { get; set;  }
        /// <summary>
        /// (optional)
        /// The transactions RVN change will be sent to this address
        /// </summary>
        [JsonPropertyName("change_address")]
        public string? ChangeAddress { get; set;  }
        /// <summary>
        /// (optional)
        /// The transactions Asset change will be sent to this address
        /// </summary>
        [JsonPropertyName("asset_change_address")]
        public string? AssetChangeAddress { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            // nulls are valid.
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(AssetName);
            Parameters.Add(Quantity);
            Parameters.Add(ToAddress);
            Parameters.Add(Message);
            Parameters.Add(ExpireTime);
            Parameters.Add(ChangeAddress);
            Parameters.Add(AssetChangeAddress);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
