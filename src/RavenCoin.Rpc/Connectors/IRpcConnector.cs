using RavenCoin.Rpc.Requests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Connectors
{
    public interface IRpcConnector
    {
        T MakeRequest<T>(JsonRpcRequest request);//(RpcMethods method, params object[] parameters);
    }
}
