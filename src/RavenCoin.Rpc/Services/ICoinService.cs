using RavenCoin.Rpc.Requests;

namespace RavenCoin.Rpc.Services
{
    public interface ICoinService : ICoinParameters
    {
        public T MakeRequest<T>(JsonRpcRequest request) where T : class;
    }
}