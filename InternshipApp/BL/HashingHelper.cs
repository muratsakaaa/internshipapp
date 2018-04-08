using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public static class HashingHelper
    {
        public static string HashingPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            var md5data = md5.ComputeHash(data);
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            return hashedPassword;
        }
    }
}
