using RavenCoin.Rpc.Connectors;
using RavenCoin.Rpc.Requests;
using RavenCoin.Rpc.Requests.AssetRequests;
using RavenCoin.Rpc.Requests.BlockchainRequests;
using RavenCoin.Rpc.Responses.AssetResponses;
using RavenCoin.Rpc.Responses.BlockchainResponses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Services
{
    public partial class CoinService : ICoinService
    {
        protected readonly IRpcConnector _rpcConnector;
        public CoinParameters Parameters { get; }
        public CoinService()
        {
            _rpcConnector = new RpcConnector(this);
            Parameters = new CoinParameters(this, null, null, null, null, 0);
        }

        public CoinService(bool useTestnet) : this()
        {
            Parameters.UseTestnet = useTestnet;
        }

        public CoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword)
        {
            _rpcConnector = new RpcConnector(this);
            Parameters = new CoinParameters(this, daemonUrl, rpcUsername, rpcPassword, walletPassword, 0);
        }

        //  this provides support for cases where *.config files are not an option
        public CoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword, short rpcRequestTimeoutInSeconds)
        {
            _rpcConnector = new RpcConnector(this);
            Parameters = new CoinParameters(this, daemonUrl, rpcUsername, rpcPassword, walletPassword, rpcRequestTimeoutInSeconds);
        }
        public T MakeRequest<T>(JsonRpcRequest request) where T : class
        {
            return _rpcConnector.MakeRequest<T>(request);
        }
    }
}
