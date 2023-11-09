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
        /// <summary>
        /// Submits raw transaction (serialized, hex-encoded) to local node and network.
        /// Transaction must first be Created, then signed
        /// </summary>
        public SendRawTransactionRequest(): base()
        {
            Id = 1;
            Method = RpcMethods.sendrawtransaction.ToString();
            Transaction = string.Empty;
        }

        /// <summary>
        /// The Hex string of the raw, signed transaction
        /// </summary>
        [JsonPropertyName("hexstring")]
        public string Transaction {  get; set; }
        /// <summary>
        /// Allow high Fees (Dangerous, you don't want to mark this as true)
        /// </summary>
        [JsonPropertyName("allowhighfees")]
        public bool? AllowHighFees { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            Parameters.Add(Transaction);
            // Nulls are valid
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(AllowHighFees);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
