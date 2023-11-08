using RavenCoin.Rpc;
using RavenCoin.Rpc.Requests.RawTransactions;
using RavenCoin.Rpc.Responses.AssetResponses;
using RavenCoin.Rpc.Services;
using System.Globalization;
using System.Text;

namespace DemoRavenRPC
{
    internal class Program
    {
        private static readonly ICoinService ravenCoinService = new RavenCoinService();
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Testing Assets . . . ");
            Console.WriteLine();
            Console.WriteLine("Testing Add Tag To Adddress: ");

            Console.WriteLine();
            Console.WriteLine("Testing List My Assets: ");
            var listMyAssetsResponse = ravenCoinService.ListMyAssets();
            foreach (Asset a in listMyAssetsResponse.Assets)
            {
                Console.WriteLine($"Name: {a.AssetName}, Value: {a.AssetValue}");
            }

            Console.WriteLine();
            Console.WriteLine("Begin Testing Blockchain . . . ");
            Console.WriteLine();
            Console.WriteLine("Testing Get Block Count: ");
            var GetBlockCountResponse = ravenCoinService.GetBlockCount();
            Console.WriteLine(GetBlockCountResponse.Result);

            Console.WriteLine();
            Console.WriteLine("Begin Testing Raw Transactions . . . ");
            Console.WriteLine();
            CreateRawTransactionRequest createRawTransactionRequest = new CreateRawTransactionRequest();
            CreateRawTransactionInput input = new CreateRawTransactionInput();
            input.TxId = "68869bb60f8ee67bab8d004f67c5691a2fd87ba3b916ba6a8493a18d48934ac0";
            input.Vout = 0;
            KeyValuePair<string, decimal> output = new KeyValuePair<string, decimal>("mpFceQeEMBy5bYkeBMDo5qT2Cq7pGN13nk", 100);
            createRawTransactionRequest.AddInput(input);
            createRawTransactionRequest.AddOutput(output);
            var CreateRawTransactionResponse = ravenCoinService.CreateRawTransaction(createRawTransactionRequest);
            var rawTransaction = CreateRawTransactionResponse.Result;
            Console.WriteLine(rawTransaction);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Begin Testing Wallet . . . ");
            Console.WriteLine("Testing List Transactions: ");
            var ListTransactionsResponse = ravenCoinService.ListTransactions("*", 100, 0, true);
            if (ListTransactionsResponse.Results != null)
            {
                foreach (var result in ListTransactionsResponse.Results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No Transactions");
            }

            Console.WriteLine();
            Console.WriteLine("TestsComplete");
            Console.ReadLine();
        }
    }
}