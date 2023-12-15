using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemorys
{
    public class InMemoryProductDal : IProductDal
    {
        //Simdilik Memory de veri varmış gibi yapıyoruz. Sonra EntityFramework den DB den verileri çekeceğiz.

        List<Product> _product=new List<Product>//Global olduğu için backend de başına _(alt çizgi) koyarız (_product).
        { 
            new Product(){ProductID=1,CategoryID=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
            new Product(){ProductID=1,CategoryID=1,ProductName="Kamera",UnitsInStock=3,UnitPrice=500},
            new Product(){ProductID=1,CategoryID=2,ProductName="Telefon",UnitsInStock=2,UnitPrice=1500},
            new Product(){ProductID=1,CategoryID=2,ProductName="Klavye",UnitsInStock=65,UnitPrice=150},
            new Product(){ProductID=1,CategoryID=2,ProductName="Fare",UnitsInStock=85,UnitPrice=1},

        }; 
        


        public void Add(Product product)
        {
            _product.Add(product);
        }

        public List<Product> GetAllByCategory(int categoryID)
        {

          return _product.Where(p => p.CategoryID == categoryID).ToList();
            //Where, içindeki şarta uyan tüm elemanları yeni bir liste haline getirir ve onu döndürür.
            //sql deki where koşulu gibi.

        }

        public void Delete(Product product)
        {
            // _product.Remove(product); Kodu bu şekilde yazınca listeden eleman silmez. Çünkü Referans tipler referans numarası üzerinden gider. Bunlarla aynı referans numarasına sahip olmadığı için silmez.
            //Yani yukarıdaki list de tanımladığımız productlar ile bu metotta tanımlanan Product product ın referans numarası aynı değildir.
            //Bu sorunu çözmek için karşımıza Link kavramı çıkar.
            //LINQ, c# ı diğer dillerden ayıran önemli bir kavramdır.
            //LINQ - Language Integrated Query - Dile gömülü sorgulama
            //LINQ ile liste bazlı yapıları aynı sql sorguları gibi filtreleyebiliyoruz.


            Product productToDelete;
            productToDelete = _product.SingleOrDefault(p=>p.ProductID==product.ProductID); // Her p için p nin ID sini (yani o an dolaştığım ürünün ID sini)  benim parametre ile gönderdiğim ürünün ID sine eşitse onun referansını productToDelete ye eşitle.
            //ID bazlı yapılarda SingleOrDefault kullanmak önemlidir. Tek sonuç gelir, birden fazla sonuç gelirse hatalıdır.


            //SingleOrDefault, _product listesindeki ürünleri tek tek gezmeye yarar.
            //p=> ; p için demektir. Buna Lambda denir. p, tek tek dolaşırken ki verdiğimiz takma isimdir, foreach deki takma isim gibi düşünülebilinir.
            //Aslında bizim bu kod ile yapmak istediğimiz tam olarak aşşağıdaki kod şeklindedir ;
            //foreach(var p in _product)
            //{
            //    if (product.ProductID == p.ProductID)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //uzun uzun bunu yazmaktansa LINQ sorguları ile yapmamız çok daha mantıklı.
            //.NET de LINQ kavramı çok çok çokkk önemlidir.
        }

        public List<Product> GetAll()
        {
            //DB deki datayı Bussines a vermemiz gerekiyor.
            //Neden Bussines a veriyoruz çünkü şu an Data Access kısmındayız.
            //Data Access de biz db den data  lar çekiyorduk,Businnes kısmında ise çekilen bu veriler ile ilgili işlemler yapılıyordu.

            return _product;
        }

        public void Update(Product product)
        {
            Product productToUpdate;
            productToUpdate = _product.SingleOrDefault(p => p.ProductID == product.ProductID);
            //yukarıdaki sorgu göndereceğimiz ürünün id'sine sahip olan listedeki ürünü bulur.

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        
        
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
