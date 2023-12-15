using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //abstractvalidator-> Fluentvalidatorun içerisinden bir yapı

        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2);//rulefor kuralları yazıyoruz.
            //produuctName i minimum 2 karakter dedik.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);//unitprice 0 dan büyük olsun demek
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1).WithMessage("Error");
            //categoryid==1(misal meyve suyu kategorisi ise) meyvesuyu kategorisdei ürünlerin fiyatı 10 ya da 10 dan büyük olmalı
            //ctrl+k+d textlerin düzenli yazılmasını sağlıyor

            //olmayan bir kural eklemek istersek must kullanabiliriz.
            RuleFor(p=>p.ProductName).Must(StartWithA).WithMessage("Urunler A harfi ile başlamalı");//StartWithA yöntemini oluşturmamız gerekir.
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");//ProductName true dönüyor mu demek
            //arg-->c# içerisindeki fonksiyondur. bool döner.

        }
    }
}
