using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class CreateRawTransactionOutput
    {
        public string Address { get; set; }
        public decimal Amount { get; set; }
    }
}
