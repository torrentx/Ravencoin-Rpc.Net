using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    internal class AddTagToAddressRequest : JsonRpcRequest
    {
        public AddTagToAddressRequest()
        {
            Id = 1;
            Method = RpcMethods.addtagtoaddress.ToString();
        }
        string tag_name { get; set; }
        string to_address { get; set; }
        string change_address { get; set; }
        string asset_data { get; set; }

        public override void FlushParameters()
        {
            Parameters = new List<object>();
            Parameters.Add(tag_name);
            Parameters.Add(to_address);
            Parameters.Add(change_address);
            Parameters.Add(asset_data);
        }
    }
}