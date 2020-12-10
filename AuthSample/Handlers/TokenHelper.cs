using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AuthSample.Handlers
{
    public class TokenHelper
    {
        public const string Issuer = "http://skpatel.net";
        public const string Audience = "http://skpatel.net";

        /// <summary>
        /// Base 64 encoded string 
        /// </summary>
        public const string Secret = "ASDBFTUIO098YOPITYUIO777345J14JLYTUIOD8ND66DDL2334LLLJJJS";

        public static string GenerateSecureSecret()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }
    }
}
