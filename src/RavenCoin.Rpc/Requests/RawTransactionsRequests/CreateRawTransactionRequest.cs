using RavenCoin.Rpc.Responses.AssetResponses;

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class CreateRawTransactionRequest : JsonRpcRequest
    {
        /// <summary>
        /// Create a transaction spending the given inputs and creating new outputs.
        /// Outputs are addresses (paired with a RVN amount, data or object specifying an asset operation) or data.
        /// Note that the transaction's inputs are not signed, and it is not stored in the wallet or transmitted to the network.
        /// Paying for Asset Operations: Some operations require an amount of RVN to be sent to a burn address.
        /// Operation: Amount + Burn Address
        ///         transfer: 0
        ///         transferwithmessage: 0
        ///         issue: " + i64tostr(GetBurnAmount(AssetType::ROOT) / COIN) + " to " + GetBurnAddress(AssetType::ROOT) +
        ///         issue(subasset) : " + i64tostr(GetBurnAmount(AssetType::SUB) / COIN) + " to " + GetBurnAddress(AssetType::SUB) +
        ///         issue_unique: " + i64tostr(GetBurnAmount(AssetType::UNIQUE) / COIN) + " to " + GetBurnAddress(AssetType::UNIQUE) +
        ///         reissue: " + i64tostr(GetBurnAmount(AssetType::REISSUE) / COIN) + " to " + GetBurnAddress(AssetType::REISSUE) +
        ///         issue_restricted: " + i64tostr(GetBurnAmount(AssetType::RESTRICTED) / COIN) + " to " + GetBurnAddress(AssetType::RESTRICTED) +
        ///         reissue_restricted: " + i64tostr(GetBurnAmount(AssetType::REISSUE) / COIN) + " to " + GetBurnAddress(AssetType::REISSUE) +
        ///         issue_qualifier: " + i64tostr(GetBurnAmount(AssetType::QUALIFIER) / COIN) + " to " + GetBurnAddress(AssetType::QUALIFIER) +
        ///         issue_qualifier(sub) : " + i64tostr(GetBurnAmount(AssetType::SUB_QUALIFIER) / COIN) + " to " + GetBurnAddress(AssetType::SUB_QUALIFIER) +
        ///         tag_addresses: " + "0.1 to " + GetBurnAddress(AssetType::NULL_ADD_QUALIFIER) + " (per address)
        ///         untag_addresses: " + "0.1 to " + GetBurnAddress(AssetType::NULL_ADD_QUALIFIER) + " (per address)
        ///         freeze_addresses: 0
        ///         unfreeze_addresses: 0
        ///         freeze_asset: 0
        ///         unfreeze_asset: 0 Assets For Authorization: These operations require a specific asset input for authorization:
        ///Root Owner Token:
        ///         reissue
        ///         issue_unique
        ///         issue_restricted
        ///         reissue_restricted
        ///         freeze_addresses
        ///         unfreeze_addresses
        ///         freeze_asset
        ///         unfreeze_asset
        ///Root Qualifier Token:
        ///         issue_qualifier(when issuing subqualifier)
        ///Qualifier Token:
        ///         tag_addresses
        ///         untag_addresses
        ///Output Ordering: Asset operations require the following:

        ///All coin outputs come first(including the burn output).
        ///The owner token change output comes next(if required).
        ///An issue, reissue, or any number of transfers comes last
        ///(different types can't be mixed in a single transaction).
        /// </summary>
        public CreateRawTransactionRequest()
        {
            Id = 1;
            Method = RpcMethods.createrawtransaction.ToString();
            Inputs = new List<CreateRawTransactionInput>();
            Outputs = new Dictionary<string,decimal>();
        }

        public CreateRawTransactionRequest(IList<CreateRawTransactionInput> inputs, Dictionary<string,decimal> outputs) : this()
        {
            Id = 1;
            Method = RpcMethods.createrawtransaction.ToString();
            Inputs = inputs;
            Outputs = outputs;
        }

        [JsonPropertyName("inputs")]
        public IList<CreateRawTransactionInput> Inputs { get; }
        [JsonPropertyName("outputs")]
        public Dictionary<string,decimal> Outputs { get; }
        [JsonPropertyName("locktime")]
        public int? Locktime { get; set; }

        public void AddInput(CreateRawTransactionInput input)
        {
            Inputs.Add(input);
        }

        public void AddOutput(KeyValuePair<string,decimal> output)
        {
            Outputs.Add(output.Key, output.Value);
        }

        internal override void FlushParameters()
        {
            Parameters.Clear();
            Parameters.Add(Inputs);
            Parameters.Add(Outputs);
            // Nulls are valid
#pragma warning disable CS8604 // Possible null reference argument.
            Parameters.Add(Locktime);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
