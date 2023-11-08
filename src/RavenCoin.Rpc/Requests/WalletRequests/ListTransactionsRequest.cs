using System.Security.Principal;

namespace RavenCoin.Rpc.Requests.WalletRequests
{
    public  class ListTransactionsRequest : JsonRpcRequest
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
        }

        public override void FlushParameters()
        {
            this.Parameters = new List<object>();
            this.Parameters.Add(Account);
            this.Parameters.Add(Count);
            this.Parameters.Add(From);
            this.Parameters.Add(IncludeWatchonly);

        }
    }
}