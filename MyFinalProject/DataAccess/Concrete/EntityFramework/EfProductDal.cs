using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {

        //EfEntityrepositoryBase de IProductDal ın istediği imzalar bulunuyor
        //Bu şekilde yapınca IProductDal da bulunan metodları burada çağırmak zorunda kalmıyoruz.
        //Peki IProductDal a neden ihtiyac var, yazmasak olur mu? -> Şu an EntityFramework kullanılıyor
        //fakat belki ilerleyen zamanlarda farklı bir teknolojiye geçmemiz gerekir,
        //kodun değişebilir olması için bu gereklidir. 
        public List<ProductDetailDto> GetProductDetails()
        {
            using(NorthWindContext context=new NorthWindContext())
            {
                //sql de yaptığımız joinlerin linq karşılığı
                  var result=from p in context.Products//products a p de,
                  join c in context.Categories//categoriye c de
                  on p.CategoryID equals c.CategoryID//products ile categories i join yap eşittir yerine equals kullanılır.
                  select new ProductDetailDto { 
                      ProductId=p.ProductID,
                      ProductName=p.ProductName,
                      CategoryName=c.CategoryName,
                      UnitInStock=p.UnitsInStock
                  };
                return result.ToList();
                //sonucu şu kolonlara uydurarak ver 


                  
                  
                  }
        }
    }
}
