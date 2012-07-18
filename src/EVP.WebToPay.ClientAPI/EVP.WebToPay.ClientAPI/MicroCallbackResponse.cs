using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVP.WebToPay.ClientAPI
{
    public class MicroCallbackResponse : ICallbackResponse
    {

        public const string STATUS_OK = "OK";
        public const string STATUS_NOSMS = "NOSMS";
        public const string STATUS_WAPPUSH = "WAPPUSH";

        private MicroCallbackResponseStatus _status;
        private string _message;


        public MicroCallbackResponse(MicroCallbackResponseStatus status)
            : this(status, null)
        {
        }


        public MicroCallbackResponse(MicroCallbackResponseStatus status, string message)
        {
            this._status = status;
            this._message = message;
        }


        public override string ToString()
        {
            switch (this._status)
            {
                case MicroCallbackResponseStatus.Ok:
                    return MicroCallbackResponse.STATUS_OK + " " + this._message;
                case MicroCallbackResponseStatus.NoSms:
                    return MicroCallbackResponse.STATUS_NOSMS;
                case MicroCallbackResponseStatus.WapPush:
                    return MicroCallbackResponse.STATUS_WAPPUSH + " " + this._message;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
