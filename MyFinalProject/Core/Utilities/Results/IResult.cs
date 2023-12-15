using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç :Yani voidler bu IResult yapısı ile süslüyor olacağız.
    public interface IResult
    {
        bool Success { get; }//Sadece okunabilir demektir.
        // Bu yapı propertie oluyor.
        //Bu properties yapılan işlemin başarılı mı başarısız mı olduğunu söyleyecek
        string Message { get; }
        //Yapılan işlemlerle ilgili bilgilendirme yapıcak


    }
}
