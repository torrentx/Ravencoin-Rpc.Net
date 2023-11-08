using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenCoin.Rpc.Constants;
using RavenCoin.Rpc.Services;

namespace RavenCoin.Rpc
{
    public class CoinParameters
    {
        #region Constructor

        public CoinParameters(ICoinService coinService,
            string? daemonUrl,
            string? rpcUsername,
            string? rpcPassword,
            string? walletPassword,
            short rpcRequestTimeoutInSeconds)
        {
            if (!string.IsNullOrWhiteSpace(daemonUrl))
            {
                DaemonUrl = daemonUrl;
                UseTestnet = false; //  this will force the CoinParameters.SelectedDaemonUrl dynamic property to automatically pick the daemonUrl defined above
                IgnoreConfigFiles = true;
                RpcUsername = rpcUsername;
                RpcPassword = rpcPassword;
                WalletPassword = walletPassword;
            }

            if (rpcRequestTimeoutInSeconds > 0)
            {
                RpcRequestTimeoutInSeconds = rpcRequestTimeoutInSeconds;
            }
            else
            {

                if (short.TryParse(ConfigurationManager.AppSettings.Get("RpcRequestTimeoutInSeconds"), out short rpcRequestTimeoutTryParse))
                {
                    RpcRequestTimeoutInSeconds = rpcRequestTimeoutTryParse;
                }
            }

            if (IgnoreConfigFiles && (string.IsNullOrWhiteSpace(DaemonUrl) || string.IsNullOrWhiteSpace(RpcUsername) || string.IsNullOrWhiteSpace(RpcPassword)))
            {
                throw new Exception($"One or more required parameters, as defined in {GetType().Name}, were not found in the configuration file!");
            }

            if (IgnoreConfigFiles && Debugger.IsAttached && string.IsNullOrWhiteSpace(WalletPassword))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[WARNING] The wallet password is either null or empty");
                Console.ResetColor();
            }


            #region RavenCoin

            else if (coinService is RavenCoinService)
            {
                if (!IgnoreConfigFiles)
                {
                    DaemonUrl = ConfigurationManager.AppSettings.Get("Ravencoin_DaemonUrl");
                    DaemonUrlTestnet = ConfigurationManager.AppSettings.Get("Ravencoin_DaemonUrl_Testnet");
                    RpcUsername = ConfigurationManager.AppSettings.Get("Ravencoin_RpcUsername");
                    RpcPassword = ConfigurationManager.AppSettings.Get("Ravencoin_RpcPassword");
                    WalletPassword = ConfigurationManager.AppSettings.Get("Ravencoin_WalletPassword");
                }

                CoinShortName = "RVN";
                CoinLongName = "RavenCoin";
                IsoCurrencyCode = "RVN";

                TransactionSizeBytesContributedByEachInput = 148;
                TransactionSizeBytesContributedByEachOutput = 34;
                TransactionSizeFixedExtraSizeInBytes = 10;

                FreeTransactionMaximumSizeInBytes = 1000;
                FreeTransactionMinimumOutputAmountInCoins = 0.01M;
                FreeTransactionMinimumPriority = 57600000;
                FeePerThousandBytesInCoins = 0.0001M;
                MinimumTransactionFeeInCoins = 0.0001M;
                MinimumNonDustTransactionAmountInCoins = 0.0000543M;

                TotalCoinSupplyInCoins = 21000000;
                EstimatedBlockGenerationTimeInMinutes = 10;
                BlocksHighestPriorityTransactionsReservedSizeInBytes = 50000;

                BaseUnitName = "Satoshi";
                BaseUnitsPerCoin = 100000000;
                CoinsPerBaseUnit = 0.00000001M;
            }
            else
            {
                throw new Exception("Unknown coin!");
            }

            #endregion

            #region Invalid configuration / Missing parameters

            if (RpcRequestTimeoutInSeconds <= 0)
            {
                throw new Exception("RpcRequestTimeoutInSeconds must be greater than zero");
            }

            if (string.IsNullOrWhiteSpace(DaemonUrl)
                || string.IsNullOrWhiteSpace(RpcUsername)
                || string.IsNullOrWhiteSpace(RpcPassword))
            {
                throw new Exception($"One or more required parameters, as defined in {GetType().Name}, were not found in the configuration file!");
            }

            #endregion
        }

        #endregion

        public string? BaseUnitName { get; set; }
        public uint BaseUnitsPerCoin { get; set; }
        public int BlocksHighestPriorityTransactionsReservedSizeInBytes { get; set; }
        public int BlockMaximumSizeInBytes { get; set; }
        public string? CoinShortName { get; set; }
        public string? CoinLongName { get; set; }
        public decimal CoinsPerBaseUnit { get; set; }
        public string? DaemonUrl { private get; set; }
        public string? DaemonUrlTestnet { private get; set; }
        public double EstimatedBlockGenerationTimeInMinutes { get; set; }
        public int ExpectedNumberOfBlocksGeneratedPerDay => (int)EstimatedBlockGenerationTimeInMinutes * GlobalConstants.MinutesInADay;
        public decimal FeePerThousandBytesInCoins { get; set; }
        public short FreeTransactionMaximumSizeInBytes { get; set; }
        public decimal FreeTransactionMinimumOutputAmountInCoins { get; set; }
        public int FreeTransactionMinimumPriority { get; set; }
        public bool IgnoreConfigFiles { get; }
        public string? IsoCurrencyCode { get; set; }
        public decimal MinimumNonDustTransactionAmountInCoins { get; set; }
        public decimal MinimumTransactionFeeInCoins { get; set; }
        public decimal OneBaseUnitInCoins => CoinsPerBaseUnit;
        public uint OneCoinInBaseUnits => BaseUnitsPerCoin;
        public string? RpcPassword { get; set; }
        public short RpcRequestTimeoutInSeconds { get; set; }
        public string? RpcUsername { get; set; }
        public string? SelectedDaemonUrl => !UseTestnet ? DaemonUrl : DaemonUrlTestnet;
        public ulong TotalCoinSupplyInCoins { get; set; }
        public int TransactionSizeBytesContributedByEachInput { get; set; }
        public int TransactionSizeBytesContributedByEachOutput { get; set; }
        public int TransactionSizeFixedExtraSizeInBytes { get; set; }
        public bool UseTestnet { get; set; }
        public string? WalletPassword { get; set; }
    }
}
