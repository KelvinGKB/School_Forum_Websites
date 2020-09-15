using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Assignment_Web_Application_
{
    public class Security
    {
        public static string Encrypt(string username, string password)
        {
            var result = new StringBuilder();
            string realResult;

            for (int i = 0; i < username.Length; i++)
            {
                char character = username[i];

                uint charCode = (uint)character;

                int keyposition = i % password.Length;

                char keychar = password[keyposition];

                uint keyCode = (uint)keychar;

                uint combinedCode = charCode ^ keyCode;

                char combinedChar = (char)combinedCode;

                result.Append(combinedChar);
            }
            realResult = GetHash(result.ToString());

            return realResult;
        }

        public static string GetHash(string strPass)
        {
            byte[] binPass = Encoding.Default.GetBytes(strPass);

            SHA256 sha = SHA256.Create();
            byte[] binHash = sha.ComputeHash(binPass);
            string strHash = Convert.ToBase64String(binHash);

            return strHash;
        }
    }
}