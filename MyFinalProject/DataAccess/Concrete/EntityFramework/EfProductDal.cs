using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthWindContext context=new NorthWindContext())
            {
                //addedEntity-> eklenen varlık
                var addedEntity = context.Entry(entity);// veri kaynağından gönderdiğimiz productta bir tane nesneyi eşleştir.
                addedEntity.State = EntityState.Added;//yakalanan referans ı ekle
                context.SaveChanges();//değişiklikleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthWindContext context=new NorthWindContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
            
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
           using(NorthWindContext context=new NorthWindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
                //bu yapı tek bir data getirir.
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthWindContext context=new NorthWindContext())
            {
                //eger filtre verilmemişse db de ilgili tablodaki tüm datayı getirsin
                // filtre vermişse o filtreye uygum dataları getir.

                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
                //db deki tüm product verilerini listeler
                //context.Set<Product>(): Bu ifade, "context" nesnesi üzerinden "Product" varlık kümesini temsil eden bir sorgu oluşturmak için kullanılır.
                //"Set<T>()" yöntemi, belirli bir veri türü için bir varlık kümesi döndürür.
                // iki noktadan öncesi sağlanmazsa sonrasını çalıştırır. 

            }
        }

        public void Update(Product entity)
        {
            using(NorthWindContext context=new NorthWindContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
