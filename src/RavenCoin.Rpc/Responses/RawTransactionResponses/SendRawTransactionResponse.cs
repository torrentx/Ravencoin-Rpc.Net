﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.RawTransactionResponses
{
    public class SendRawTransactionResponse : JsonRpcResponse
    {
        public SendRawTransactionResponse(string id, JsonRpcError error) :base (id,error) { }

        [JsonPropertyName("result")]
        public string? Result { get; set; }
    }
}
