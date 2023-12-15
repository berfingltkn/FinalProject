using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
//namespace-> biz interfacleri ya da yapılarımızı belli bir isim uzayının içine bırakıyoruz ki daha rahat ulaşabilelim.

{
    //generic constrain: generic kısıtlar.
    //class: referans tip
    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı. Bunu yazmamızın nedeni IEntity i yazmasın fakat IEntityden implemente olanlar yazılabilsin istiyoruz
    //bu yüzden IEntity bir interface olduğu için ne interfaceler new lenemedikleri için new() yazdık.
    public interface IEntityRepository<T> where T:class,IEntity,new()
        //boyle yapınca generic constrain oluyor. T nin hangi yapıda olması gerektiğini belirtiyoruz.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//filter=null filtre vermeyebilirsin demek.
        //Expression yapısı ile filtrelemek istediğinde tek tek gidip yazmana gerek kalmamış oluyor.

        T Get(Expression<Func<T,bool>>filter);//burada filtre zorunlu, tek tek detay şekilde filtrelemek için kullanıcaz.
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
