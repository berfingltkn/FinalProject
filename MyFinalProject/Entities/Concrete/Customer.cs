using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }//id yi string olarak tanımladık çünkü kullandığımız hazır veritabanında string olarak ayarlanmış
        public string ContactName{get;set;}
        public string CompanyName{get;set;}
        public string City{get;set;}
        
    }
}
