﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Requests.AssetRequests
{
    internal class ListMyAssetsRequest : JsonRpcRequest
    {
        public ListMyAssetsRequest()
        {
            Id = 1;
            Method = RpcMethods.listmyassets.ToString();
        }
        //string tag_name { get; set; }
        //string to_address { get; set; }
        //string change_address { get; set; }
        //string asset_data { get; set; }

        public override void FlushParameters()
        {
            //this.Parameters = new List<object>();
            //this.Parameters.Add(tag_name);
            //this.Parameters.Add(to_address);
            //this.Parameters.Add(change_address);
            //this.Parameters.Add(asset_data);
        }
    }
}