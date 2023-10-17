using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //Her zaman işlem yapılacak şeyin interface ini oluşturmayı unutma.
        //Bu gereksiz görünebilir fakat proje yönetiminde 5 10 yıl sonrası için önemli bir olaydır.

        //Class ı public yapmayı unutmuyoruz.  

        }
}
