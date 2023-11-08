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
            Parameters = new List<object>();
            Method = RpcMethods.unknown.ToString();
        }
        public JsonRpcRequest(int id, string method, params object[] parameters)
        {
            Id = id;
            Method = method;
            Parameters = parameters?.ToList() ?? new List<object>();
        }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("params")]
        public IList<object> Parameters { get; set; }

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
            return JsonSerializer.Serialize(this);
        }

        public abstract void FlushParameters();
    }
}
