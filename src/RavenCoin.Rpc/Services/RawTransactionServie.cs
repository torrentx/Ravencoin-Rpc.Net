using RavenCoin.Rpc.Requests.RawTransactions;
using RavenCoin.Rpc.Responses.RawTransactionResponses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Services
{
    public partial class CoinService : ICoinService
    {
        public CreateRawTransactionResponse CreateRawTransaction(CreateRawTransactionRequest request)
        {
            {
                return _rpcConnector.MakeRequest<CreateRawTransactionResponse>(request);
            }
        }
    }
}
