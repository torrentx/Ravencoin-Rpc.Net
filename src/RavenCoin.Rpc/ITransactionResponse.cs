using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc
{
    public interface ITransactionResponse
    {
        string? TxId { get; set; }
    }
}
