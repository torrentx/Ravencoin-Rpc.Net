using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests
{
    public abstract class JsonRpcRequest
    {
        public JsonRpcRequest() 
        {
            Id = 1;
            Method = RpcMethods.unknown.ToString();
            Parameters = new List<object>();
        }
        public JsonRpcRequest(int id, string method)
        {
            Id = id;
            Method = method;
            Parameters = new List<object>();
        }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("params")]
        public List<object> Parameters { get; set; }

        /// <summary>
        /// [JsonProperty(PropertyName = "id", Order = 2)]
        /// </summary>
        public int Id { get; set; }

        public byte[] GetBytes()
        {
            var json = JsonSerializer.Serialize(this);
            return Encoding.UTF8.GetBytes(json);
        }

        public string JsonString()
        {
            this.FlushParameters();
            return JsonSerializer.Serialize(this);
        }

        internal abstract void FlushParameters();
    }
}
