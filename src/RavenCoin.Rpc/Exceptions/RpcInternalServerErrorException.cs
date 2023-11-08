using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RavenCoin.Rpc.Exceptions
{
    [Serializable]
    public class RpcInternalServerErrorException : Exception
    {
        public RpcInternalServerErrorException()
        {
        }

        public RpcInternalServerErrorException(string customMessage) : base(customMessage)
        {
        }

        public RpcInternalServerErrorException(string customMessage, Exception exception) : base(customMessage, exception)
        {
        }

        public RpcErrorCode? RpcErrorCode { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("RpcErrorCode", RpcErrorCode, typeof(RpcErrorCode));
            base.GetObjectData(info, context);
        }
    }
}
