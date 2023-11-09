using RavenCoin.Rpc.Responses.AssetResponses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class IssueUniqueRequest : JsonRpcRequest
    {
        /// <summary>
        /// Issue unique asset(s).
        /// root_name must be an asset you own.
        /// An asset will be created for each element of asset_tags.
        /// If provided ipfs_hashes must be the same length as asset_tags.
        /// Five (5) RVN will be burned for each asset created.
        /// </summary>
        public IssueUniqueRequest() : base(1, RpcMethods.issueunique.ToString())
        {
            RootName = string.Empty;
            AssetTags = new List<string>();
        }

        /// <summary>
        /// Name o the asset theunique asset(s) are being issued under
        /// </summary>
        [JsonPropertyName("root_name")]
        public string RootName { get; set; }
        
        /// <summary>
        /// The unique tag for each asset which is to be issued
        /// </summary>
        [JsonPropertyName("asset_tags")]
        public List<string> AssetTags { get; set; }

        /// <summary>
        /// Ipfs hashes or txid hashes corresponding to each supplied tag (should be same size as "asset_tags")
        /// </summary>
        [JsonPropertyName("ipfs_hashes")]
        public List<string>? Ipfs { get; set; }

        /// <summary>
        /// Address asses will be sent to, if it is empty address will be generated for you
        /// </summary>
        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; } = "";
        /// <summary>
        /// Address the rvn change will be sent to, if it is empty, change address will be generated for you.
        /// </summary>
        [JsonPropertyName("change_address")]
        public string ChangeAddress { get; set; } = "";

        internal override void FlushParameters()
        {
            Parameters.Clear();
            Parameters.Add(RootName);
            Parameters.Add(AssetTags);
            // Null is a valid parameter
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(Ipfs);
            Parameters.Add(ToAddress);
            Parameters.Add(ChangeAddress);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
