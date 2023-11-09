using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class SignRawTransactionRequest : JsonRpcRequest
    {
        /// <summary>
        /// Sign inputs for raw transaction (serialized, hex-encoded).
        /// The second optional argument (may be null) is an array of previous transaction outputs that this transaction depends on but may not yet be in the block chain.
        /// The third optional argument (may be null) is an array of base58-encoded private keys that, if given, will be the only keys used to sign the transaction.
        /// </summary>
        public SignRawTransactionRequest(): base()
        {
            Id = 1;
            Method = RpcMethods.signrawtransaction.ToString();
            Transaction = string.Empty;
        }

        /// <summary>
        /// The transaction hex string
        /// </summary>
        [JsonPropertyName("hexstring")]
        public string Transaction {  get; set; }
        /// <summary>
        /// (optional)
        /// Array of json objects, or 'null' if none provided
        /// </summary>
        [JsonPropertyName("prevtxs")]
        public List<SignRawTransactionInput>? Inputs { get; set; }
        /// <summary>
        /// (optional)
        /// Array of strings, or 'null' if none provided. Private key in base58-encoding
        /// </summary>
        [JsonPropertyName("privkeys")]
        public List<string>? PrivateKeys { get; set; }
        /// <summary>
        /// (optional)
        /// The signature hash type
        /// 'ALL' | 'NONE' | 'SINGLE' | 'ALL|ANYONECANPAY' | 'NONE|ANYONECANPAY' | 'SINGLE|ANYONECANPAY'. 
        /// Default = ALL. 
        /// </summary>
        [JsonPropertyName("sighashtype")]
        public string? SigHashType { get; set; }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            Parameters.Add(Transaction);
            // Nulls are valid.
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(Inputs);
            Parameters.Add(PrivateKeys);
            Parameters.Add(SigHashType);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void AddInput(SignRawTransactionInput signRawTransactionInput)
        {
            if (Inputs == null) { Inputs = new List<SignRawTransactionInput>(); }
            Inputs.Add(signRawTransactionInput);
        }

        public void AddKey(string privateKey)
        {
            if (PrivateKeys == null) {  PrivateKeys = new List<string>(); }
            PrivateKeys.Add(privateKey);
        }
    }
}
