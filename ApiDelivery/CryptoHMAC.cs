using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ApiDelivery
{
    public static class CryptoHMAC
    {
        public static string GetHMAC(string publicKey, string Milliseconds, string secretKey)
        {
            var encoding = new ASCIIEncoding();
            var hmacsha1 = new HMACSHA1(encoding.GetBytes(secretKey));
            var message = hmacsha1.ComputeHash(encoding.GetBytes(publicKey + Milliseconds));
            return ByteToString(message);
        }

        public static string ByteToString(byte[] buff)
        {
            var sbinary = new StringBuilder();
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary.Append(buff[i].ToString("X2")); // hex format
            }
            return sbinary.ToString();
        }
    }
}
