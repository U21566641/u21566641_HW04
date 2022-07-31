using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace u21566641_HW04
{
    public static class Cryptography
    {
        //To be used to hash the password in order to securely store it
        public static string Hash(string value)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash
                (Encoding.UTF8.GetBytes(value)));
        }
    }
}