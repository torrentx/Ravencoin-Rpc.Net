using RavenCoin.Rpc;
using RavenCoin.Rpc.Responses.AssetResponses;
using RavenCoin.Rpc.Services;
using System.Globalization;

namespace DemoRavenRPC
{
    internal class Program
    {
        private static readonly ICoinService CoinService = new RavenCoinService();
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Testing Assets . . . ");
            Console.WriteLine();
            Console.WriteLine("Testing Add Tag To Adddress: ");

            Console.WriteLine();
            Console.WriteLine("Testing List My Assets: ");
            var listMyAssetsResponse = CoinService.ListMyAssets();
            foreach (Asset a in listMyAssetsResponse.Assets)
            {
                Console.WriteLine($"Name: {a.AssetName}, Value: {a.AssetValue}");
            }

            Console.WriteLine();
            Console.WriteLine("Begin Testing Blockchain . . . ");
            Console.WriteLine();
            Console.WriteLine("Testing Get Block Count: ");
            var GetBlockCountResult = CoinService.GetBlockCount();
            Console.WriteLine(GetBlockCountResult.Result);

            Console.WriteLine();
            Console.WriteLine("Begin Testing Wallet . . . ");
            Console.WriteLine("Testing List Transactions: ");
            var ListTransactionsResponse = CoinService.ListTransactions("*", 100, 0, true);
            foreach(var result in ListTransactionsResponse.Results)
            {
                Console.WriteLine(result);
            }

            Console.WriteLine();
            Console.WriteLine("TestsComplete");
            Console.ReadLine();
        }
    }
}