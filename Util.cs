using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Case_Deti
{
    public static class Util
    {
        public static byte[] GetEncryptedBytes(string text)
        {
            HashAlgorithm sha = SHA256.Create();
            byte[] text_bytes = Encoding.UTF8.GetBytes(text);
            return sha.ComputeHash(text_bytes);
        }
    }
}
