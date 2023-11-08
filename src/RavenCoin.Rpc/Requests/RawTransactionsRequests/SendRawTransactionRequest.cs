using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class SendRawTransactionRequest : JsonRpcRequest
    {
        public SendRawTransactionRequest(): base()
        {
            Id = 1;
            Method = RpcMethods.sendrawtransaction.ToString();
        }

        [JsonPropertyName("hexstring")]
        public string? Transaction {  get; set; }

        internal override void FlushParameters()
        {
            Parameters = new List<object>();
            if (Transaction != null)
            {
                Parameters.Add(Transaction);
            }
        }
    }
}
