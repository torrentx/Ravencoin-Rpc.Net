using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class IssueRequest : JsonRpcRequest
    {
        /// <summary>
        /// Issue an asset, subasset or unique asset.
        /// </summary>
        public IssueRequest() 
        {
            Id = 1;
            Method = RpcMethods.issue.ToString();
            AssetName = string.Empty;
        }
        /// <summary>
        /// (required) A unique name
        /// </summary>
        [JsonPropertyName("asset_name")]
        public string AssetName { get; set; }

        /// <summary>
        /// (optional - but cannot be null)
        /// Default is 1
        /// Number of units to be issued
        /// </summary>
        [JsonPropertyName("qty")]
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// (optional)
        /// Address asset will be sent to
        /// </summary>
        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; } = "";

        /// <summary>
        /// Address the rvn change will be sent to
        /// </summary>
        [JsonPropertyName("change_address")]
        public string ChangeAddress { get; set; } = "";

        /// <summary>
        /// (optional)
        /// Min = 0, Max = 8
        /// Number of decimals precisionfor the asset
        /// </summary>
        [JsonPropertyName("units")]
        public int Units { get; set; } = 0;

        /// <summary>
        /// (optional)
        /// Whether future reissuance is allowed
        /// </summary>
        [JsonPropertyName("reissuable")]
        public bool Reissuable { get; set; } = true;

        /// <summary>
        /// Whether ipfs hash is going to be added to the asset
        /// </summary>
        [JsonPropertyName("has_ipfs")]
        public bool? HasIpfs { get; set; } = false;

        /// <summary>
        /// (optional)
        /// Required if has_ipfs is true. 
        /// </summary>
        [JsonPropertyName("ipfs_hash")]
        public string? Ipfs { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            Parameters.Add(AssetName);
            Parameters.Add(Quantity);
            Parameters.Add(ToAddress);
            Parameters.Add(ChangeAddress);
            Parameters.Add(Units);
            Parameters.Add(Reissuable);
            Parameters.Add(HasIpfs);
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(Ipfs);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
