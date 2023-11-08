using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenCoin.Rpc.Constants;
using RavenCoin.Rpc.Requests;

namespace RavenCoin.Rpc.Services
{
    public class RavenCoinService : CoinService, IRavenCoinService
    {
        public RavenCoinService(bool useTestnet = false) : base(useTestnet)
        {
        }

        public RavenCoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword)
            : base(daemonUrl, rpcUsername, rpcPassword, walletPassword)
        {
        }

        public RavenCoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword, short rpcRequestTimeoutInSeconds)
            : base(daemonUrl, rpcUsername, rpcPassword, walletPassword, rpcRequestTimeoutInSeconds)
        {
        }

        public RavenCoinConstants.Constants Constants => RavenCoinConstants.Constants.Instance;
    }
}
