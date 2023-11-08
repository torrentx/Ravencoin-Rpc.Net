using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.RawTransactions
{
    public class ScriptSig
    {
        public string? Asm { get; set; }
        public string? Hex { get; set; }
    }
}
