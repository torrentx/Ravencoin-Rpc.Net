using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class ListMyAssetsRequest : JsonRpcRequest
    {
        /// <summary>
        /// Returns a list of all asset that are owned by this wallet
        /// </summary>
        public ListMyAssetsRequest()
        {
            Id = 1;
            Method = RpcMethods.listmyassets.ToString();
        }

        /// <summary>
        /// (optional)
        /// Filters results -- mustbe an asset name or a partial asset name followed by *
        /// </summary>
        [JsonPropertyName("asset")]
        public string Asset { get; set; } = "*";
        /// <summary>
        /// (optional)
        /// When false results only contain balances, when true reults include outpoints
        /// </summary>
        [JsonPropertyName("verbose")]
        public bool Verbose { get; set; } = false;
        /// <summary>
        /// (optional)
        /// Truncates results to include only the first count of assets found
        /// </summary>
        [JsonPropertyName("count")]
        public int? Count { get; set; } = int.MaxValue;
        /// <summary>
        /// (optional)
        /// Results skip over the first start assets found (if negative it skips back from the end)
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; } = 0;
        /// <summary>
        /// (optional)
        /// Results are skipped if they don't have this number of confirmations
        /// </summary>
        [JsonPropertyName("confs")]
        public int Confirmations { get; set; } = 0;

        internal override void FlushParameters()
        {
            Parameters.Clear();
            // Nulls are valid
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(Asset);
            Parameters.Add(Verbose);
            Parameters.Add(Count);
            Parameters.Add(Start);
            Parameters.Add(Confirmations);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}