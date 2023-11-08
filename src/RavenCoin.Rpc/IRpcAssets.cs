using RavenCoin.Rpc.Responses.AssetResponses;

namespace RavenCoin.Rpc
{
    public interface IRpcAssets
    {
        ListAssetResponse ListMyAssets();
    }
}