using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WaterAMR.Utility
{
    public static class Security
    {
        public static string EncrptPassword(string strPassword)//M014
        {
            HashAlgorithm mhash = System.Security.Cryptography.SHA1.Create();//  new SHA1CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(strPassword);
            byte[] byteHash = mhash.ComputeHash(byteValue);
            //mhash.Clear();
            return Convert.ToBase64String(byteHash);
        }
    }
}
