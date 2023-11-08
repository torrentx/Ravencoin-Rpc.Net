using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Constants
{
    public abstract class CoinConstants<T> where T : CoinConstants<T>, new()
    {
        private static readonly Lazy<T> Lazy = new(() => new T());
        public static T Instance => Lazy.Value;
    }
}
