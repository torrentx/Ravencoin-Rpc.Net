using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.RawTransactions
{
    public class CreateRawTransactionRequest : JsonRpcRequest
    {
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

        public IList<CreateRawTransactionInput> Inputs { get; }
        public Dictionary<string,decimal> Outputs { get; }

        public void AddInput(CreateRawTransactionInput input)
        {
            Inputs.Add(input);
        }

        public void AddOutput(KeyValuePair<string,decimal> output)
        {
            Outputs.Add(output.Key, output.Value);
        }

        public void AddInput(string? txId, int vout)
        {
            Inputs.Add(new CreateRawTransactionInput
            {
                TxId = txId,
                Vout = vout
            });
        }

        public void AddOutput(string address, decimal amount)
        {
            Outputs.Add(address, amount);
        }

        public bool RemoveInput(CreateRawTransactionInput input)
        {
            return Inputs.Contains(input) && Inputs.Remove(input);
        }

        public bool RemoveOutput(KeyValuePair<string,decimal> output)
        {
            return RemoveOutput(output.Key, output.Value);
        }

        public bool RemoveInput(string? txId, int vout)
        {
            var input = Inputs.FirstOrDefault(x => x.TxId == txId && x.Vout == vout);
            return input != null && Inputs.Remove(input);
        }

        public bool RemoveOutput(string address, decimal amount)
        {
            var outputToBeRemoved = new KeyValuePair<string, decimal>(address, amount);
            return Outputs.Contains<KeyValuePair<string, decimal>>(outputToBeRemoved) && Outputs.Remove(outputToBeRemoved.Key);
        }

        public override void FlushParameters()
        {
            Parameters = new List<object>
            {
                Inputs,
                Outputs
            };
        }
    }
}
