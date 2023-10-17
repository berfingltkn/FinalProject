using Businnes.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Concrete
{
   public class ProductManager:IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {

            //Data Access den çağırmamız gerekiyor.
            //diyelim ki burada iş kodları var( örneğin eğer ... şartlarını sağlıyorsa gibi)


            return _productDal.GetAll();
            // Data Access deki yani veritabanındaki verilerden GetAll metodunu çalıştır.
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryID==id);
       //categoryId, bizim gönderdiğimiz id ye eşitse listele diyoruz.

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice >= max);
        }
    }
}
