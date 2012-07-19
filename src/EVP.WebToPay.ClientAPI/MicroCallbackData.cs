using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVP.WebToPay.ClientAPI
{
    public class MicroCallbackData : ICallbackData
    {

        private string _to;
        private string _message;
        private string _from;
        private string _operator;
        private int _amount;
        private string _currency;
        private string _country;
        private int _smsId;
        private bool _test;
        private string _keyword;
        private int _projectId;
        private string _version;


        public MicroCallbackData(Dictionary<string, string> dataQueryParams)
        {
            this._to = dataQueryParams["to"];
            this._message = dataQueryParams["sms"];
            this._from = dataQueryParams["from"];
            this._operator = dataQueryParams["operator"];
            this._amount = int.Parse(dataQueryParams["amount"]);
            this._currency = dataQueryParams["currency"];
            this._country = dataQueryParams["country"];
            this._smsId = int.Parse(dataQueryParams["id"]);
            this._test = HttpQueryUtility.QueryParameterToBoolean(dataQueryParams["test"]);
            this._keyword = dataQueryParams["key"];
            this._projectId = int.Parse(dataQueryParams["projectid"]);
            this._version = dataQueryParams["version"];
        }


        public string To
        {
            get { return this._to; }
        }


        public string Message
        {
            get { return this._message; }
        }


        public string From
        {
            get { return this._from; }
        }


        public string Operator
        {
            get { return this._operator; }
        }


        public int Amount
        {
            get { return this._amount; }
        }


        public string Currency
        {
            get { return this._currency; }
        }


        public string Country
        {
            get { return this._country; }
        }


        public int SmsId
        {
            get { return this._smsId; }
        }


        public bool Test
        {
            get { return this._test; }
        }


        public string Keyword
        {
            get { return this._keyword; }
        }


        public int ProjectId
        {
            get { return this._projectId; }
        }


        public string Version
        {
            get { return this._version; }
        }

    }
}
