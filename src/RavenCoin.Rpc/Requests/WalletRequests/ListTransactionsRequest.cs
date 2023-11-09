using System.Security.Principal;
using System.Text.Json.Serialization;

namespace RavenCoin.Rpc.Requests.WalletRequests
{
    public class ListTransactionsRequest : JsonRpcRequest
    {
        /// <summary>
        /// Returns up to 'count' most recent transactions skipping the first 'from' transactions for account 'account'.
        /// </summary>
        /// <param name="account">DEPRECATED Should always be "*"</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="from">The number of transactions to skip</param>
        /// <param name="includeWatchonly">Include Transactions to watch-only addresses</param>
        public ListTransactionsRequest(string account, int count, int from, bool includeWatchonly)
        {
            this.Id = 1;
            this.Method = RpcMethods.listtransactions.ToString();
            Account = account;
            Count = count;
            From = from;
            IncludeWatchonly = includeWatchonly;
            Parameters = new List<object>();
        }

        /// <summary>
        /// DEPRECATED Should always be "*"
        /// </summary>
        public string? Account { get; set; } = "*";
        /// <summary>
        /// The number of transactions to return
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        ///The number of transactions to skip
        /// </summary>
        public int? From { get; set; }
        /// <summary>
        /// Include Transactions to watch-only addresses
        /// </summary>
        public bool? IncludeWatchonly { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            // Nulls are valid.
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(Account);
            Parameters.Add(Count);
            Parameters.Add(From);
            Parameters.Add(IncludeWatchonly);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}