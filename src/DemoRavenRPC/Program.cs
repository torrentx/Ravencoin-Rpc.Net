using RavenCoin.Rpc;
using RavenCoin.Rpc.Requests.AssetRequests;
using RavenCoin.Rpc.Requests.BlockchainRequests;
using RavenCoin.Rpc.Requests.RawTransactions;
using RavenCoin.Rpc.Requests.WalletRequests;
using RavenCoin.Rpc.Responses.AssetResponses;
using RavenCoin.Rpc.Responses.BlockchainResponses;
using RavenCoin.Rpc.Responses.RawTransactionResponses;
using RavenCoin.Rpc.Responses.WalletResponses;
using RavenCoin.Rpc.Services;

using System.Globalization;
using System.Text;

namespace DemoRavenRPC
{
    internal class Program
    {
        private static readonly ICoinService ravenCoinService = new RavenCoinService();
        static void Main()
        {
            Console.WriteLine("Begin Testing Assets . . . ");
            Console.WriteLine();
            //AddTagToAddress();
            GetAssetData("<test>");
            //GetSnapshot,
            //GetVerifierString,
            // IssueAsset(GenerateUniqueAssetName()); // *Expensive to Test
            //IssueQualifierAsset,
            //IssueRestrictedAsset,
            IssueUnique("<test>",GenerateUniqueAssetName(), "");
            //IsValidVerifierString,
            //ListAddressesByAsset,
            //ListAddressesForTag,
            //ListAddressRestrictions,
            //ListAssetBalanceByAddress,
            //ListAssets,
            //ListAssetsResponse,
            //ListMyAssets,
            ListMyAssets();
            //ListTagsForAddress,
            //PurgeSnapshot,
            //PurgeSnapshotResponse,
            //Reissue,
            //ReissueRestrictedAsset,
            //RemoveTagFromAddress,

            Transfer("PROJECTCC/CRYPTOS", 0.1M, "<address>", "", 0, "<address>", "<address>");
            
            //TransferFromAddress,
            //TransferFromAddresses,
            //TransferQualifier,
            //UnfreezeAddress,
            //UnfreezeRestrictedAsset

            Console.WriteLine();
            Console.WriteLine("Begin Testing Blockchain . . . ");
            Console.WriteLine();
            GetBlockCount();

            Console.WriteLine();
            Console.WriteLine("Begin Testing Raw Transactions . . . ");
            Console.WriteLine();
            // Be Super Careful Here - Use testnet while learning how these work. 
            //string? transactionHex = CreateRawTransaction();
            //string? signedTransactionHex = SignRawTransaction(transactionHex ?? "");
            //SendRawTransaction(signedTransactionHex ?? "");

            Console.WriteLine();
            Console.WriteLine("Begin Testing Wallet . . . ");
            Console.WriteLine();
            ListTransactions();

            Console.WriteLine();
            Console.WriteLine("Tests Complete!");
            Console.ReadLine();
        }

        private static string GenerateUniqueAssetName()
        {
            Guid guid = Guid.NewGuid();
            string guidAsName = guid.ToString();
            string cleanName = guidAsName.Replace("-", string.Empty);
            string truncatedName = cleanName.Substring(0, 30);
            return truncatedName.ToUpper();
        }

        private static void IssueAsset(string assetName)
        {
            Console.WriteLine();
            Console.WriteLine("Testing Issue");
            IssueRequest request = new IssueRequest();
            request.AssetName = assetName;
            IssueResponse response = ravenCoinService.MakeRequest<IssueResponse>(request);
            Console.Write(response);

            Console.WriteLine();
        }

        private static void IssueUnique(string baseAsset, string uniqueAsset, string ipfsTag)
        {
            uniqueAsset = uniqueAsset.Substring(0, 30-baseAsset.Length);
            Console.WriteLine();
            Console.WriteLine("Testing Issue Unique");
            IssueUniqueRequest request = new IssueUniqueRequest();
            request.RootName = baseAsset;
            request.AssetTags.Add(uniqueAsset);
            request.ToAddress = "<address>";
            IssueUniqueResponse response = ravenCoinService.MakeRequest<IssueUniqueResponse>(request);
            Console.Write(response);
            Console.WriteLine();
        }

        private static void Transfer(string assetName, decimal qty, string toAddress, string message, long expireTime, string changeAddress, string assetChangeAddress)
        {
            Console.WriteLine();
            Console.WriteLine("Testing Transfer");
            TransferRequest request = new()
            {
                AssetName = assetName,
                Quantity = qty,
                ToAddress = toAddress,
                Message = message,
                ExpireTime = expireTime,
                ChangeAddress = changeAddress,
                AssetChangeAddress = assetChangeAddress,
            };
            TransferResponse response = ravenCoinService.MakeRequest<TransferResponse> (request);
            Console.Write(response.ToString());
            Console.WriteLine();
        }

        private static void GetAssetData(string assetName)
        {
            Console.WriteLine();
            Console.WriteLine("Testing Get Asset Data: ");
            GetAssetDataRequest request = new()
            {
                AssetName = assetName
            };
            var response = ravenCoinService.MakeRequest<GetAssetDataResponse>(request);

            Console.Write(response.ToString());

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void ListMyAssets()
        {
            Console.WriteLine();
            Console.WriteLine("Testing List My Assets: ");
            ListMyAssetsRequest request = new();
            var listMyAssetsResponse = ravenCoinService.MakeRequest<ListAssetResponse>(request);
            foreach (Asset a in listMyAssetsResponse.Assets)
            {
                Console.WriteLine($"Name: {a.AssetName}, Value: {a.AssetValue}");
            }
            Console.WriteLine();
        }

        private static void AddTagToAddress()
        {
            Console.WriteLine();
            Console.WriteLine("Testing Add Tag To Adddress: ");


            Console.WriteLine();
        }

        private static void ListTransactions()
        {
            Console.WriteLine();
            Console.WriteLine("Testing List Transactions: ");
            ListTransactionsRequest request = new("*", 1000, 0, true);
            ListTransactionsResponse listTransactionsResponse = ravenCoinService.MakeRequest<ListTransactionsResponse>(request);
            if (listTransactionsResponse.Results != null)
            {
                foreach (var result in listTransactionsResponse.Results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No Transactions");
            }
            Console.WriteLine();
        }

        private static void GetBlockCount()
        {
            Console.WriteLine("Testing Get Block Count: ");
            GetBlockCountRequest getBlockCountRequest = new ();
            var GetBlockCountResponse = ravenCoinService.MakeRequest<GetBlockCountResponse>(getBlockCountRequest);
            Console.WriteLine(GetBlockCountResponse.Result);
        }

        private static string? CreateRawTransaction()
        {
            Console.WriteLine();
            Console.WriteLine("Testing Create Raw Transaction");
            CreateRawTransactionRequest createRawTransactionRequest = new();
            CreateRawTransactionInput input = new()
            {
                TxId = "<list unused transaction>",
                Vout = 1
            };
            KeyValuePair<string, decimal> output = new("<receiving Address>", 100);
            KeyValuePair<string, decimal> output2 = new("<receiving Address>", 7794.96093100M);
            createRawTransactionRequest.AddInput(input);
            createRawTransactionRequest.AddOutput(output);
            createRawTransactionRequest.AddOutput(output2);
            var createRawTransactionResponse = ravenCoinService.MakeRequest<CreateRawTransactionResponse>(createRawTransactionRequest);
            var rawTransaction = createRawTransactionResponse.Result;
            if (createRawTransactionResponse.Error != null)
            {
                Console.WriteLine(createRawTransactionResponse.Error.Message);
            }
            Console.WriteLine(rawTransaction);
            Console.WriteLine();
            return rawTransaction;
        }

        private static string? SignRawTransaction(string transaction)
        {
            Console.WriteLine();
            Console.WriteLine("Testing Sign Raw Transaction");
            SignRawTransactionRequest signRawTransactionRequest = new()
            {
                Transaction = transaction,
            };
            signRawTransactionRequest.AddKey("<privkey>");
            var SignRawTransactionResponse = ravenCoinService.MakeRequest<SignRawTransactionResponse>(signRawTransactionRequest);
            var rawTransaction = SignRawTransactionResponse.Result;
            if (SignRawTransactionResponse?.Result?.Errors != null)
            {
                foreach (var error in SignRawTransactionResponse.Result.Errors)
                {
                    Console.WriteLine(error.Error);
                }
            }
            Console.WriteLine(rawTransaction?.Hex);
            Console.WriteLine();
            return rawTransaction?.Hex;
        }

        private static void SendRawTransaction(string signedTransactionHex)
        {
            Console.WriteLine();
            Console.WriteLine("Testing Send Raw Transaction");
            SendRawTransactionRequest request = new()
            {
                Transaction = signedTransactionHex
            };
            SendRawTransactionResponse response = ravenCoinService.MakeRequest<SendRawTransactionResponse>(request);
            if (response.Error != null)
            {
                Console.WriteLine(response.Error.Message);
            }
            Console.WriteLine(response.Result);
            Console.WriteLine();
        }
    }
}