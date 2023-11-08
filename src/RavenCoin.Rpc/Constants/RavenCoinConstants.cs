using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Constants
{
    public static class RavenCoinConstants
    {
        public sealed class Constants : CoinConstants<Constants>
        {
            public readonly int OneRavenCoinInSatoshis = 100000000;
            public readonly decimal OneSatoshiInRavenCoin = 0.00000001M;
            public readonly int SatoshisPerRavencoin = 100000000;
            public readonly string Symbol = "℟";
        }
    }
}