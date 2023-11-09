using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.BlockchainRequests
{
    public class GetBlockCountRequest : JsonRpcRequest
    {
        /// <summary>
        /// Returns the number of blocks in the longest blockchain.
        /// </summary>
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