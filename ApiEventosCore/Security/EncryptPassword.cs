using System;
using System.Security.Cryptography;
using System.Text;

namespace ApiEventosCore.Security
{
    public static class EncryptPassword
    {
        public static string Encode(string original)
        {
            byte[] encodedBytes;

            using (var md5 = new MD5CryptoServiceProvider())
            {
                var originalBytes = Encoding.Default.GetBytes(original);
                encodedBytes = md5.ComputeHash(originalBytes);
            }

            return Convert.ToBase64String(encodedBytes);
        }
    }
}
