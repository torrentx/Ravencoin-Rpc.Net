using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses
{
    public class JsonRpcError
    {
        //[JsonProperty(PropertyName = "code")]
        public RpcErrorCode Code { get; set; }

        //[JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
