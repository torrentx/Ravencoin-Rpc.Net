using RavenCoin.Rpc.Requests.WalletRequests;
using RavenCoin.Rpc.Responses.WalletResponses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Services
{
    public partial class CoinService : ICoinService
    {
        public ListTransactionsResponse ListTransactions(string account, int count, int from, bool? includeWatchonly)
        {
            ListTransactionsRequest request = new(account, count, from, includeWatchonly??false);
            return _rpcConnector.MakeRequest<ListTransactionsResponse>(request);
                //: _rpcConnector.MakeRequest<List<ListTransactionsResponse>>(RpcMethods.listtransactions, (string.IsNullOrWhiteSpace(account) ? "*" : account), count, from, includeWatchonly);
        }
    }
}
