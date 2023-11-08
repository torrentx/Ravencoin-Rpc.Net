using System.Security.Principal;
using System.Text.Json.Serialization;

namespace RavenCoin.Rpc.Requests.WalletRequests
{
    public class ListTransactionsRequest : JsonRpcRequest
    {
        public string Account { get; set; }
        public int Count { get; set; }
        public int From { get; set; }
        public bool IncludeWatchonly { get; set; }
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

        internal override void FlushParameters()
        {
            this.Parameters = new List<object> {
                Account,
                Count,
                From,
                IncludeWatchonly
            };

        }
    }
}