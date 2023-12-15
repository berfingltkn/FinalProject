using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class ProductDetailDto:IDto
    {
        //çıplak class kalmasın,
        //IDto yerine normalde diğer yapılarda IEntity yazdık, sen bir db tablosu musun demekti
        //ama bu yapı db tablosu değil, birden fazla tablonun birleşimi o yüzden IDto yazdık.

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitInStock { get; set; }


    }

}
