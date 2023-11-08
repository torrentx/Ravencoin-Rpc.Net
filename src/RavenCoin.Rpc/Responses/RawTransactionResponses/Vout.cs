using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.RawTransactions
{
    public class Vout
    {
        public decimal Value { get; set; }
        public int N { get; set; }
        public ScriptPubKey ScriptPubKey { get; set; }
    }
}
