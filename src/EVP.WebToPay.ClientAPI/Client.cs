using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace EVP.WebToPay.ClientAPI
{
    public class Client
    {

        public const string VERSION = "1.6";
        public const string PAY_URL = "https://bank.paysera.com/pay/";
        public const string SMS_ANSWER_URL = "https://bank.paysera.com/psms/respond/";

        private int _projectId;
        private string _signPassword;


        public Client(int projectId, string signPassword)
        {
            if (projectId < 0)
            {
                throw new ArgumentOutOfRangeException("projectId");
            }
            if (string.IsNullOrEmpty(signPassword))
            {
                throw new ArgumentNullException("signPassword");
            }
            this._projectId = projectId;
            this._signPassword = signPassword;
        }


        public MacroRequest NewMacroRequest()
        {
            MacroRequest macroRequest = new MacroRequest(this._projectId, Client.VERSION);
            return macroRequest;
        }


        public MicroAnswer NewMicroAnswer()
        {
            MicroAnswer microAnswer = new MicroAnswer(this._signPassword);
            return microAnswer;
        }


        public string BuildRequestUrl(MacroRequest request)
        {
            string data = request.ToBase64String();
            string sign = CryptoUtility.CalculateMD5(data + this._signPassword);

            Dictionary<string, string> requestQueryParams = new Dictionary<string, string>();
            requestQueryParams["data"] = data;
            requestQueryParams["sign"] = sign;

            string requestQuery = HttpQueryUtility.BuildQueryString(requestQueryParams);

            return Client.PAY_URL + "?" + requestQuery;
        }


        public MacroCallbackData GetMacroCallbackData(NameValueCollection query)
        {
            MacroCallbackData callbackData = (MacroCallbackData)this.GetCallbackData(query, PaymentType.Macro);
            return callbackData;
        }


        public MicroCallbackData GetMicroCallbackData(NameValueCollection query)
        {
            MicroCallbackData callbackData = (MicroCallbackData)this.GetCallbackData(query, PaymentType.Micro);
            return callbackData;
        }


        public string BuildRepeatRequestUrl(string orderId)
        {
            MacroRequest request = this.NewMacroRequest();
            request.OrderId = orderId;
            request.RepeatRequest = true;
            return this.BuildRequestUrl(request);
        }


        public void SendMicroAnswer(MicroAnswer microAnswer)
        {
            string url = Client.SMS_ANSWER_URL + "?" + microAnswer.BuildQueryString();

            string response;
            using (WebClient wc = new WebClient())
            {
                response = wc.DownloadString(url);
            }

            if (response != "OK")
            {
                throw new InvalidOperationException(response);
            }
        }


        private ICallbackData GetCallbackData(NameValueCollection query, PaymentType paymentType)
        {
            if (string.IsNullOrEmpty(query["data"]))
            {
                throw new ArgumentNullException("data");
            }
            string dataAsBase64 = query["data"];

            if (string.IsNullOrEmpty(query["ss2"]))
            {
                throw new ArgumentNullException("ss2");
            }
            string ss2AsBase64 = query["ss2"];

            string publicKeyPEMFileContents = CryptoUtility.DownloadPublicKey();
            byte[] publicKeyRawData = CryptoUtility.GetPublicKeyRawDataFromPEMFile(publicKeyPEMFileContents); ;
            byte[] ss2 = CryptoUtility.DecodeBase64UrlSafeAsByteArray(ss2AsBase64);

            bool valid = CryptoUtility.VerifySS2(dataAsBase64, ss2, publicKeyRawData);
            if (!valid)
            {
                throw new InvalidOperationException("Signed data validation failed (SS2).");
            }

            string dataQuery = CryptoUtility.DecodeBase64UrlSafe(dataAsBase64);

            Dictionary<string, string> dataQueryParams = HttpQueryUtility.ParseQueryString(dataQuery);

            ICallbackData callbackData;
            switch (paymentType)
            {
                case PaymentType.Macro:
                    MacroCallbackData macroCallbackData = new MacroCallbackData(dataQueryParams);
                    callbackData = macroCallbackData;
                    break;
                case PaymentType.Micro:
                    MicroCallbackData microCallbackData = new MicroCallbackData(dataQueryParams);
                    callbackData = microCallbackData;
                    break;
                default:
                    throw new NotSupportedException("Payment type " + paymentType + " is not supported.");
            }

            if (callbackData.ProjectId != this._projectId)
            {
                throw new Exception("Bad project Id " + callbackData.ProjectId + " should be " + this._projectId + ".");
            }

            return callbackData;
        }

    }
}
