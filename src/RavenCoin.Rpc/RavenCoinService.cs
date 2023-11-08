using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenCoin.Rpc.Services;

namespace RavenCoin.Rpc
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

        //public string SendToAddress(string ravencoinaddress, decimal amount, string comment, string commentTo, bool subtractFeeFromAmount, bool allowReplaceByFee)
        //{
        //    return _rpcConnector.MakeRequest<string>(RpcMethods.sendtoaddress, ravencoinaddress, amount, comment, commentTo, subtractFeeFromAmount, allowReplaceByFee);
        //}

        //public string GetNewAddress(string account = "", string addressType = "")
        //{
        //    return string.IsNullOrWhiteSpace(account)
        //        ? _rpcConnector.MakeRequest<string>(RpcMethods.getnewaddress)
        //        : _rpcConnector.MakeRequest<string>(RpcMethods.getnewaddress, account, addressType);
        //}
    }
}
