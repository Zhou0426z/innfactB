using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace innfact.Helper
{
    public static class AccountHelper
    {
        public static string EncodePassword(string password)
        {
            if(password == null)
            {
                return "";
            }
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] source = Encoding.Default.GetBytes(password);
            byte[] crypto = sha256.ComputeHash(source);
            string result = Convert.ToBase64String(crypto);
            return result;

        }
    }
}
