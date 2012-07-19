using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVP.WebToPay.ClientAPI
{
    public class MacroCallbackResponse : ICallbackResponse
    {

        public const string STATUS_OK = "OK";

        private MacroCallbackResponseStatus _status;


        public MacroCallbackResponse(MacroCallbackResponseStatus status)
        {
            this._status = status;
        }


        public override string ToString()
        {
            switch (this._status)
            {
                case MacroCallbackResponseStatus.Ok:
                    return MacroCallbackResponse.STATUS_OK;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
