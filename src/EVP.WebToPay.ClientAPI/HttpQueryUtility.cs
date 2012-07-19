using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System;

namespace EVP.WebToPay.ClientAPI
{
    internal class HttpQueryUtility
    {

        public static string BuildQueryString(Dictionary<string, string> queryParams)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> queryParam in queryParams)
            {
                if (string.IsNullOrEmpty(queryParam.Value))
                {
                    continue;
                }

                if (sb.Length > 0)
                {
                    sb.Append("&");
                }
                sb.Append(HttpUtility.UrlEncode(queryParam.Key));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(queryParam.Value));
            }

            return sb.ToString();
        }


        public static Dictionary<string, string> ParseQueryString(string queryString)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            NameValueCollection queryParamCollection = HttpUtility.ParseQueryString(queryString);
            foreach (string key in queryParamCollection.AllKeys)
            {
                queryParams[key] = queryParamCollection[key];
            }
            return queryParams;
        }


        public static string ToQueryParameter(bool? boolValue)
        {
            if (boolValue != null)
            {
                if (boolValue.Value)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return null;
            }
        }


        public static bool QueryParameterToBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            if (value == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string ToQueryParameter(int? intValue)
        {
            if (intValue != null)
            {
                return intValue.ToString();
            }
            else
            {
                return null;
            }
        }


        public static string ToQueryParameter(List<string> stringValues)
        {
            if (stringValues != null)
            {
                return string.Join(",", stringValues.ToArray());
            }
            else
            {
                return null;
            }
        }

    }
}
