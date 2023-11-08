using RavenCoin.Rpc.Requests.RawTransactions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.RawTransactionResponses
{
    public class SignRawTransactionResponse : JsonRpcResponse
    {
        public SignRawTransactionResponse(string id, JsonRpcError error) :base (id,error) { }

        [JsonPropertyName("result")]
        public SignRawTransactionResponseResult? Result { get; set; }

        
    }
    public class SignRawTransactionResponseResult
    {
        [JsonPropertyName("hex")]
        public string? Hex { get; set; }
        [JsonPropertyName("complete")]
        public bool? Completed { get; set; }

        [JsonPropertyName("errors")]
        public List<SignRawTransactionResponseError>? Errors { get; set; }
    }

    public class SignRawTransactionResponseError
    {
        [JsonPropertyName("txid")]
        public string? Txid { get; set; }
        [JsonPropertyName("vout")]
        public int Vout { get; set; }
        [JsonPropertyName("witness")]
        public List<object>? Witness { get; set; }
        [JsonPropertyName("scriptsig")]
        public string? ScriptSig { get; set; }
        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }
        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
