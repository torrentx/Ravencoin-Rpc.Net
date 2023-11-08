namespace RavenCoin.Rpc.Services
{
    public interface ICoinService : IRpcService, IRpcExtenderService, ICoinParameters, IRpcAssets, IWalletService,IRawTransactionService
    {
    }
}