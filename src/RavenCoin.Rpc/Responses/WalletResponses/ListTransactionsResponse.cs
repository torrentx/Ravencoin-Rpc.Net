using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.WalletResponses
{
    public class ListTransactionsResponse : JsonRpcResponse
    {
        public ListTransactionsResponse(string id, JsonRpcError error) : base(id, error){ }
        
        [JsonPropertyName("result")]
        public List<ListTransactionsResponseResult>? Results { get; set; }
    }
    public class ListTransactionsResponseResult
    {
        [JsonPropertyName("account")]
        public string? Account { get; set; }
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("label")]
        public string? Label { get; set; }
        [JsonPropertyName("vout")]
        public int Vout { get; set; }
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        [JsonPropertyName("confirmations")]
        public int Confirmations { get; set; }
        [JsonPropertyName("blockhash")]
        public string? BlockHash { get; set; }
        [JsonPropertyName("blockindex")]
        public double BlockIndex { get; set; }
        [JsonPropertyName("blocktime")]
        public double BlockTime { get; set; }
        [JsonPropertyName("txid")]
        public string? TxId { get; set; }
        [JsonPropertyName("walletconflicts")]
        public List<string>? WalletConflicts { get; set; }
        [JsonPropertyName("time")]
        public double Time { get; set; }
        [JsonPropertyName("timereceived")]
        public double TimeReceived { get; set; }
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }
        [JsonPropertyName("otheraccount")]
        public string? OtherAccount { get; set; }
        [JsonPropertyName("involveswatchonly")]
        public bool InvolvesWatchonly { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Account: {Account}");
            sb.Append(Environment.NewLine);
            sb.Append($"Address: {Address}");
            sb.Append(Environment.NewLine);
            sb.Append($"Amount: {Amount}");

            return sb.ToString();
        }
    }
}
