using RavenCoin.Rpc.Responses.WalletResponses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Services
{
    public interface IWalletService
    {
        public ListTransactionsResponse ListTransactions(string account, int count = 10, int from = 0, bool? includeWatchonly = null);
    }
}
