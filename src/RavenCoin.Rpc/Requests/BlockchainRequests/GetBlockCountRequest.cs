using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.BlockchainRequests
{
    public class GetBlockCountRequest : JsonRpcRequest
    {
        public GetBlockCountRequest()
        {
            Id = 1;
            Method = RpcMethods.getblockcount.ToString();
        }

        internal override void FlushParameters()
        {
        }
    }
}