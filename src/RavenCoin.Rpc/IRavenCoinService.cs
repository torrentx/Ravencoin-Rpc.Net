using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenCoin.Rpc.Services;

namespace RavenCoin.Rpc
{
    public interface IRavenCoinService : ICoinService, IRavenCoinConstants
    {
    }
}
