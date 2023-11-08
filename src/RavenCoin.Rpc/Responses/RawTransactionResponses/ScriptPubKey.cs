using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Responses.RawTransactions
{
    public class ScriptPubKey
    {
        public string Asm { get; set; }
        public string Hex { get; set; }
        public int ReqSigs { get; set; }
        public string Type { get; set; }
        public List<string> Addresses { get; set; }
    }
}
