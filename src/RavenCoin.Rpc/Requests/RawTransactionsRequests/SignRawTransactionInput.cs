using System.Text.Json.Serialization;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class SignRawTransactionInput
    {
        [JsonPropertyName("txid")]
        public string? TxId { get; set; }

        [JsonPropertyName("vout")]
        public int Vout { get; set; }

        [JsonPropertyName("scriptPubKey")]
        public string? ScriptPubKey { get; set; }

        [JsonPropertyName("redeemScript")]
        public string? RedeemScript { get; set; }
    }
}