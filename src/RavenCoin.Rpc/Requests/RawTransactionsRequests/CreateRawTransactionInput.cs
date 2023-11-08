using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class CreateRawTransactionInput
    {
        //[JsonProperty("txid")]
        public string TxId { get; set; }

        //[JsonProperty("vout")]
        public int Vout { get; set; }
    }
}
