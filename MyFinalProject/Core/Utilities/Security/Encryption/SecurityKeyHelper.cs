using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //işin içinde şifreleme olan her şeyde byte formatında veri yollamamız gerekiyor.
        //yani asp.net deki jwt nin anlayacağı formata getirmemiz gerekiyor.

        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //anahtarlar simetrik ve simetrik olmayan olarak ikiye ayrılıyor. Biz burada simetrik olanı kullanacağımızı söylüyoruz.


        }
    }
}
