using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class CreateRawTransactionInput
    {
        [JsonPropertyName("txid")]
        public string TxId { get; set; }

        [JsonPropertyName("vout")]
        public int Vout { get; set; }
    }
}
