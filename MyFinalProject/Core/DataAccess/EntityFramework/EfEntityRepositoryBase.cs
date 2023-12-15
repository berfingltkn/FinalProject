using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
       where TContext:DbContext,new()
       //dbContext ->entityframeworkCore dan geliyor.
    {//bir tane tablo ve bir tane de context tipi istiyoruz.

        //entity framework kullanarak bir repository base i oluştur demektir.


        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //addedEntity-> eklenen varlık
                var addedEntity = context.Entry(entity);// veri kaynağından gönderdiğimiz productta bir tane nesneyi eşleştir.
                addedEntity.State = EntityState.Added;//yakalanan referans ı ekle
                context.SaveChanges();//değişiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                //bu yapı tek bir data getirir.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //eger filtre verilmemişse db de ilgili tablodaki tüm datayı getirsin
                // filtre vermişse o filtreye uygum dataları getir.

                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //db deki tüm product verilerini listeler
                //context.Set<Product>(): Bu ifade, "context" nesnesi üzerinden "Product" varlık kümesini temsil eden bir sorgu oluşturmak için kullanılır.
                //"Set<T>()" yöntemi, belirli bir veri türü için bir varlık kümesi döndürür.
                // iki noktadan öncesi sağlanmazsa sonrasını çalıştırır. 

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
