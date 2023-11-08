using RavenCoin.Rpc.Requests.RawTransactions;
using RavenCoin.Rpc.Responses.RawTransactionResponses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Services
{
    public interface IRawTransactionService
    {
        public CreateRawTransactionResponse CreateRawTransaction(CreateRawTransactionRequest rawTransaction);
    }
}
