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
        public SignRawTransactionRequest(): base()
        {
            Id = 1;
            Method = RpcMethods.signrawtransaction.ToString();
            SigHashType = "ALL";
            Inputs = new List<SignRawTransactionInput>();
            PrivateKeys = new List<string>();
        }

        [JsonPropertyName("hexstring")]
        public string? Transaction {  get; set; }
        [JsonPropertyName("prevtxs")]
        public List<SignRawTransactionInput> Inputs { get; set; }
        [JsonPropertyName("privkeys")]
        public List<string> PrivateKeys { get; set; }
        [JsonPropertyName("sighashtype")]
        public string? SigHashType { get; set; }

        internal override void FlushParameters()
        {
            Parameters = new List<object>();
            if (Transaction != null)
            {
                Parameters.Add(Transaction);
            }
            if (Inputs != null)
            {
                Parameters.Add(Inputs);
            }
            if (PrivateKeys != null)
            {
                Parameters.Add(PrivateKeys);
            }
            if (!string.IsNullOrEmpty(SigHashType))
            {
                Parameters.Add(SigHashType);
            }
        }

        public void AddInput(SignRawTransactionInput signRawTransactionInput)
        {
            Inputs.Add(signRawTransactionInput);
        }

        public void AddKey(string privateKey)
        {
            PrivateKeys.Add(privateKey);
        }
    }
}
