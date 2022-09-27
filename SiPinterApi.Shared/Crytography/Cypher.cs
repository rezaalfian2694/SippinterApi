using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPinterApi.Shared.Crytography
{
    public class Cypher
    {
        public static string Encrypt(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte xorConstant = 0x41;

                byte[] data = Encoding.UTF8.GetBytes(text);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i] ^ xorConstant);
                }
                return Convert.ToBase64String(data);
            }
            else
                return string.Empty;
        }

        public static string Decrypt(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte xorConstant = 0x41;
                byte[] data = Convert.FromBase64String(text);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i] ^ xorConstant);
                }

                return Encoding.UTF8.GetString(data);
            }
            else
                return string.Empty;
        }
    }
}
