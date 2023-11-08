using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    public class ListMyAssetsRequest : JsonRpcRequest
    {
        public ListMyAssetsRequest()
        {
            Id = 1;
            Method = RpcMethods.listmyassets.ToString();
        }

        internal override void FlushParameters()
        {
        }
    }
}