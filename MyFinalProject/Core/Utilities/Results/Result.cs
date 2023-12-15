using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //IResult un somut kısmını yapıyoruz
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success)
        {
            Message = message;//Aşağıdaki Message ı message olarak set et dedik.
            //Fakat biz aşağıdaki Message ı setlememiştik.
            //Constracture olunca set edilebilirlik özelliğini de kullanabiliriz.
            // Ama constructer dışında set edilebilirlik özelliğini kullanamayız, sadece get edebiliriz (okuyabiliriz)

          
            //this(succes)-> Aşağıdakı constructer daki yapıyı tekrar buraya yazmaktansa thissuccess) diyip hem aşağıdakini hemde bu constructerın içindekini çalıştırdık. Kendi kodumuzu tekrar etmemiş olduk.

        }

        public Result(bool success)
        {
            Success = success;
        }
        //public bool Success => throw new NotImplementedException();
        //Bu şekilde de kullanılıyor. Yeni nesil kullanım tarzı. Interface kısmında sadece get olduğundan böyle kullanabilme şansımız da var.

        public bool Success { get; }
        public string Message { get; }
    }
}
