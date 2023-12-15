using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //static bir class ın methodları da static olmalı, java da böyle değil
        public static void Validate(IValidator validator,object entity)
        {
            //validation çalıştırmak için (ilgili en spagetti code bu,);
            var context = new ValidationContext<object>(entity);//Product için  doğrulama yapacağımızı söyleyip parametreden gelen product tipinde değer döndür diyoruz.
            var result = validator.Validate(context);//productValidator kullanarak ilgili context i doğrula,validate et.
            if (!result.IsValid)//eğer sonuç geçerli değilse hata fırlat.
            {
                throw new ValidationException(result.Errors);//hata fırlatır.
            }

        }
    }
}
