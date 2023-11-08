using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Exceptions
{
    [Serializable]
    public class RpcException : Exception
    {
        public RpcException()
        {
        }

        public RpcException(string customMessage) : base(customMessage)
        {
        }

        public RpcException(string customMessage, Exception exception) : base(customMessage, exception)
        {
        }
    }
}
