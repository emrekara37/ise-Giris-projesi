using System.Security.Cryptography;
using System.Text;

namespace TeknolivaProje.Web.Helpers
{
  public static class CryptoHelper
  {
    
    public static string Md5Sifrele(this string metin)
    {

      var md5 = new MD5CryptoServiceProvider();


      var btr = Encoding.UTF8.GetBytes(metin);
      btr = md5.ComputeHash(btr);


      var sb = new StringBuilder();


      foreach (byte ba in btr)
      {
        sb.Append(ba.ToString("x2").ToLower());
      }

      var md5String = sb.ToString();

      return md5String.Substring(0, 30);
    }
  }

  
}