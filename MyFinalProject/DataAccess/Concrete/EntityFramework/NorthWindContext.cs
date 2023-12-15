using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: DB tabloları ile proje classlarını bağlar, ilişkilendirir.
    public class NorthWindContext : DbContext
    {
        //class ismini Contect vermemiz bunun context olduğu anlamına gelmiyor
        //Bu yüzden yüklediğimiz entityframework paketi ile gelen bir özelliği eklememiz gerekiyor class ın yanına DbContext  yazmalıyız.
        //class a verdiğimiz Northwind ismi kullandığımız sistemin adı


        //Bu method, benim projem hangi veri tabanı ile ilişkili yi belirttiğimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=true");//sql server kullanacağımızı belirttik.
                                                                                                                  //sql server a nasıl bağlanmamız gerektiğini de belirtmemiz gerekiyor. cift tırnak içerisindeki 
                                                                                                                  //Server = diyip bir IP yazarız. Şu an developer ortamda olduğumuz için bu IP yerine kullandığımız northwind db nin bulunduğu yeri yazarız. ama gerçek projelerde gerçek IP ler olmalı.
                                                                                                                  //Trusted_Conneciton=true yaptığımızda sisteme giriş için şifreye gerek yok demektir.


            //Bu işlemlerden sonra hangi nesnenin hangi nesneye denk geldiğini de belirtmemiz gerekiyor.
            //bunun içinde DbSet<> kullanırız.
        }
        public DbSet<Product> Products { get; set; }//Product nesnesini dbset deki Products ile bağladık.
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}


    
