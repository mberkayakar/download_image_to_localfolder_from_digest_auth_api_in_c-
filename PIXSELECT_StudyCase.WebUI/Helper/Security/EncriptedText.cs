using System.Security.Cryptography;
using System.Text;

namespace PIXSELECT_StudyCase.WebUI.Helper.Security
{
    public class EncriptedText
    {

        public static string CreateMD5Generator(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return  sb.ToString();
        }



    }
}
