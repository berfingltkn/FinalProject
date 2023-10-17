using Businnes.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemorys;
using System;

namespace ConsoleUI
{
    //SOLID
    //o-> open closed principle
    //solid kavramı mülakatlarda çok sorulmaktadır.

    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach(var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);

                //LINQ - Class - Methods - Encapsulation
                // Collections - Generic - Constructer - Inheritanca
                // Interface - Polymorphism - AbstractClass 
                // Katmanlar

            }
        }
    }
}
