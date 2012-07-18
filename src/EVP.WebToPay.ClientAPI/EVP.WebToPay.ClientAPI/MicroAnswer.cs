using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVP.WebToPay.ClientAPI
{
    public class MicroAnswer
    {

        private int _smsId;
        private string _message;
        private string _signPassword;


        internal MicroAnswer(string signPassword)
        {
            this._signPassword = signPassword;
        }


        public int SmsId
        {
            get { return _smsId; }
            set { _smsId = value; }
        }


        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        public string BuildQueryString()
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams["id"] = this._smsId.ToString();
            queryParams["msg"] = this._message;
            queryParams["transaction"] = CryptoUtility.CalculateMD5(this._signPassword + "|" + this._smsId);
            string queryString = HttpQueryUtility.BuildQueryString(queryParams);
            return queryString;
        }

    }
}
