using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.RawTransactions
{
    public class DecodeRawTransactionResponse : ITransactionResponse
    {
        public string? Version { get; set; }
        public string? LockTime { get; set; }
        public List<Vin>? Vin { get; set; }
        public List<Vout>? Vout { get; set; }
        public string? TxId { get; set; }
    }
}
