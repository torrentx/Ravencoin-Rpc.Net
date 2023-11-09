
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.AssetResponses
{
    public class IssueUniqueResponse : JsonRpcResponse
    {
        public IssueUniqueResponse(string id, JsonRpcError error) : base (id,error)
        {
        }

        [JsonPropertyName("result")]
        public List<string>? Result { get; set; }

        public override string ToString()
        {
            if (Result == null)
            {
                return this.Error?.Message??"";
            }
            StringBuilder sb = new StringBuilder();
            foreach(string txid in Result)
            {
                if (txid != null)
                {
                    sb.AppendLine(txid);
                }
            }
            return sb.ToString();            
        }
    }
}
