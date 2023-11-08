
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class GetAssetDataRequest : JsonRpcRequest
    {
        public GetAssetDataRequest()
        {
            Id = 1;
            Method = RpcMethods.getassetdata.ToString();
        }

        public GetAssetDataRequest(string assetName)
        {
            Id = 1;
            Method = RpcMethods.getassetdata.ToString();
            AssetName = assetName;
        }

        public string? AssetName { get; set; }

        internal override void FlushParameters()
        {
            Parameters = new List<object>();
            if (AssetName != null)
            {
                Parameters.Add(AssetName);
            };
        }
    }
}