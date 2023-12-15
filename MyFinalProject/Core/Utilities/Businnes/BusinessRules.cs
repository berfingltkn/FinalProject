using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Businnes
{
    public class BusinessRules
    {
        //genel iş kodlarını buraya koyuyoruz.

        public static IResult Run(params IResult[] logics)
        {
            // c# da params diye bir yapı vardır. params verdiğimizde Run içerisine istediğimiz kadar parametre olarak IResult verebiliriz.  
        //arkaplanda bütün parametreler array haline getirilip IResult a atıyor.
        //logics iş kuralları demek.,

            foreach(var logic in logics)
            {
                //parametre ile gönderdiğimiz iş kurallarına başarısız olanı Business a gönderiyoruz.
                //logic dediğimiz business katmanında iş katmanı methodlarını yazdıklarımız oluyor.
                //mevcut hata varsa direkt o hatayı döndürür.

                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
