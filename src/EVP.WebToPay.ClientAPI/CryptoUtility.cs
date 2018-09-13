using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net;

namespace EVP.WebToPay.ClientAPI
{
    internal class CryptoUtility
    {

        public static string CalculateMD5(string text)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] textAsBytes = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hash = md5.ComputeHash(textAsBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }


        public static string EncodeBase64UrlSafe(string text)
        {
            string encodedText = CryptoUtility.EncodeBase64(text);
            encodedText = encodedText.Replace('+', '-');
            encodedText = encodedText.Replace('/', '_');
            return encodedText;
        }


        public static string DecodeBase64UrlSafe(string encodedText)
        {
            encodedText = encodedText.Replace('-', '+');
            encodedText = encodedText.Replace('_', '/');
            string text = CryptoUtility.DecodeBase64(encodedText);
            return text;
        }


        public static byte[] DecodeBase64UrlSafeAsByteArray(string encodedData)
        {
            encodedData = encodedData.Replace('-', '+');
            encodedData = encodedData.Replace('_', '/');
            byte[] data = Convert.FromBase64String(encodedData);
            return data;
        }


        public static string DownloadPublicKey()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    return wc.DownloadString("https://bank.paysera.com/download/public.key");
                }
                catch (Exception ex)
                {
                    throw new Exception("Enable to download public key file :" + ex.Message, ex);
                }
            }
        }


        public static byte[] GetPublicKeyRawDataFromPEMFile(string pemFileContents)
        {
            string startCertificateMark = "-----BEGIN CERTIFICATE-----";
            string endCertificateMark = "-----END CERTIFICATE-----";
            int startCertificateIndex = pemFileContents.IndexOf(startCertificateMark);
            int endCertificateIndex = pemFileContents.IndexOf(endCertificateMark);
            string publicKeyBase64 = pemFileContents.Substring(startCertificateIndex + startCertificateMark.Length, endCertificateIndex - startCertificateIndex - endCertificateMark.Length - 2);
            publicKeyBase64 = publicKeyBase64.Trim();
            byte[] publicKeyRawData = Convert.FromBase64String(publicKeyBase64);
            return publicKeyRawData;
        }


        public static bool VerifySS2(string data, byte[] signature, byte[] publicKeyRawData)
        {
            X509Certificate2 c = new X509Certificate2(publicKeyRawData);
            RSACryptoServiceProvider p = new RSACryptoServiceProvider();
            p.FromXmlString(c.PublicKey.Key.ToXmlString(false));
            bool valid = p.VerifyData(System.Text.Encoding.UTF8.GetBytes(data), CryptoConfig.MapNameToOID("SHA1"), signature);
            return valid;
        }


        private static string EncodeBase64(string text)
        {
            byte[] textAsBytes = System.Text.Encoding.UTF8.GetBytes(text);
            String encodedText = Convert.ToBase64String(textAsBytes);
            return encodedText;
        }


        private static string DecodeBase64(string encodedText)
        {
            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            string text = System.Text.ASCIIEncoding.UTF8.GetString(textAsBytes);
            return text;
        }

    }
}
