
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class GetAssetDataRequest : JsonRpcRequest
    {
        /// <summary>
        /// Returns assets metadata if that asset exists
        /// </summary>
        public GetAssetDataRequest()
        {
            Id = 1;
            Method = RpcMethods.getassetdata.ToString();
            AssetName = string.Empty;
        }

        /// <summary>
        /// The name of the asset
        /// </summary>
        public string AssetName { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            Parameters.Add(AssetName);
        }
    }
}