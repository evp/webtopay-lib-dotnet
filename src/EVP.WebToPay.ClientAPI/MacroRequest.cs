using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVP.WebToPay.ClientAPI
{
    public class MacroRequest
    {

        private int _projectId;
        private string _orderId;
        private string _acceptUrl;
        private string _cancelUrl;
        private string _callbackUrl;
        private string _version;
        private string _language;
        private int? _amount;
        private string _currency;
        private string _payment;
        private string _country;
        private string _payText;
        private string _paypalFirstName;
        private string _paypalLastName;
        private string _email;
        private string _paypalStreet;
        private string _paypalCity;
        private string _paypalState;
        private string _paypalZip;
        private string _paypalCountryCode;
        private List<string> _allowPayments = new List<string>();
        private List<string> _disallowPayments = new List<string>();
        private bool? _test;
        private string _timeLimit;
        private string _personCode;
        private Dictionary<string, string> _additionalParameters = new Dictionary<string, string>();
        private bool? _repeatRequest;


        internal MacroRequest(int projectId, string version)
        {
            this._projectId = projectId;
            this._version = version;
        }


        private bool Validate()
        {
            //TODO: Validate()
            return true;
        }


        public string ToBase64String()
        {
            Dictionary<string, string> dataQueryParams = new Dictionary<string, string>();

            dataQueryParams["projectid"] = this._projectId.ToString();
            dataQueryParams["orderid"] = this._orderId;
            dataQueryParams["accepturl"] = this._acceptUrl;
            dataQueryParams["cancelurl"] = this._cancelUrl;
            dataQueryParams["callbackurl"] = this._callbackUrl;
            dataQueryParams["version"] = this._version;
            dataQueryParams["lang"] = this._language;
            dataQueryParams["amount"] = HttpQueryUtility.ToQueryParameter(this._amount);
            dataQueryParams["currency"] = this._currency;
            dataQueryParams["payment"] = this._payment;
            dataQueryParams["country"] = this._country;
            dataQueryParams["paytext"] = this._payText;
            dataQueryParams["p_firstname"] = this._paypalFirstName;
            dataQueryParams["p_lastname"] = this._paypalLastName;
            dataQueryParams["p_email"] = this._email;
            dataQueryParams["p_street"] = this._paypalStreet;
            dataQueryParams["p_city"] = this._paypalCity;
            dataQueryParams["p_state"] = this._paypalState;
            dataQueryParams["p_zip"] = this._paypalZip;
            dataQueryParams["p_countrycode"] = this._paypalCountryCode;
            dataQueryParams["time_limit"] = this._timeLimit;
            dataQueryParams["personcode"] = this._personCode;
            dataQueryParams["test"] = HttpQueryUtility.ToQueryParameter(this._test);
            dataQueryParams["repeat_request"] = HttpQueryUtility.ToQueryParameter(this._repeatRequest);
            dataQueryParams["only_payments"] = HttpQueryUtility.ToQueryParameter(this._allowPayments);
            dataQueryParams["disalow_payments"] = HttpQueryUtility.ToQueryParameter(this._disallowPayments);

            foreach (KeyValuePair<string, string> param in this._additionalParameters)
            {
                if (!dataQueryParams.ContainsKey(param.Key))
                {
                    dataQueryParams[param.Key] = param.Value;
                }
            }

            string dataQuery = HttpQueryUtility.BuildQueryString(dataQueryParams);
            string dataQueryAsBase64 = CryptoUtility.EncodeBase64UrlSafe(dataQuery);

            return dataQueryAsBase64;
        }


        public bool? RepeatRequest
        {
            get { return this._repeatRequest; }
            internal set { this._repeatRequest = value; }
        }


        public string PaypalState
        {
            get { return this._paypalState; }
            set { this._paypalState = value; }
        }


        public string PaypalZip
        {
            get { return this._paypalZip; }
            set { this._paypalZip = value; }
        }


        public string PaypalCountryCode
        {
            get { return this._paypalCountryCode; }
            set { this._paypalCountryCode = value; }
        }


        public bool? Test
        {
            get { return this._test; }
            set { this._test = value; }
        }

        //TODO: Change to DateTime
        public string TimeLimit
        {
            get { return this._timeLimit; }
            set { this._timeLimit = value; }
        }


        public string PersonCode
        {
            get { return this._personCode; }
            set { this._personCode = value; }
        }


        public List<string> AllowPayments
        {
            get { return this._allowPayments; }
        }


        public List<string> DisallowPayments
        {
            get { return this._disallowPayments; }
        }


        public string CallbackUrl
        {
            get { return this._callbackUrl; }
            set { this._callbackUrl = value; }
        }


        public string CancelUrl
        {
            get { return this._cancelUrl; }
            set { this._cancelUrl = value; }
        }


        public string OrderId
        {
            get { return this._orderId; }
            set { this._orderId = value; }
        }


        public string AcceptUrl
        {
            get { return this._acceptUrl; }
            set { this._acceptUrl = value; }
        }


        public string Language
        {
            get { return this._language; }
            set { this._language = value; }
        }


        public int? Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }


        public string Currency
        {
            get { return this._currency; }
            set { this._currency = value; }
        }


        public string Payment
        {
            get { return this._payment; }
            set { this._payment = value; }
        }


        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }


        public string PayText
        {
            get { return this._payText; }
            set { this._payText = value; }
        }


        public string PaypalFirstName
        {
            get { return this._paypalFirstName; }
            set { this._paypalFirstName = value; }
        }


        public string PaypalLastName
        {
            get { return this._paypalLastName; }
            set { this._paypalLastName = value; }
        }


        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }


        public string PaypalStreet
        {
            get { return this._paypalStreet; }
            set { this._paypalStreet = value; }
        }


        public string PaypalCity
        {
            get { return this._paypalCity; }
            set { this._paypalCity = value; }
        }


        public Dictionary<string, string> AdditionalParameters
        {
            get { return this._additionalParameters; }
        }

    }
}
