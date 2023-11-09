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
        /// <summary>
        /// Assign a tag to a address
        /// </summary>
        public AddTagToAddressRequest()
        {
            Id = 1;
            Method = RpcMethods.addtagtoaddress.ToString();
            TagName = string.Empty;
            ToAddress = string.Empty;
            Parameters = new List<object>();
        }

        /// <summary>
        /// The name of the tag you are assigning to the address, if it doesn'thave '#' at the front it will be added
        /// </summary>
        [JsonPropertyName("tag_name")]
        string TagName { get; set; }
        /// <summary>
        /// The address that will be assigned the tag
        /// </summary>
        [JsonPropertyName("to_address")]
        string ToAddress { get; set; }
        /// <summary>
        /// (optional)
        /// The change address for the qualifier token to be sent to
        /// </summary>
        [JsonPropertyName("change_address")]
        string? ChangeAddress { get; set; }
        /// <summary>
        /// (optional)
        /// The asset data (ipfs or hash) to be applied to the transfer of the qualifier token
        /// </summary>
        [JsonPropertyName("asset_data")]
        string? AssetData { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            // Nulls are allowed during serialiation
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(TagName);
            Parameters.Add(ToAddress);
            Parameters.Add(ChangeAddress);
            Parameters.Add(AssetData);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}