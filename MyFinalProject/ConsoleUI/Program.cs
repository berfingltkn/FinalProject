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
            //ProductTest();
            //CategoryTest(); Test etmek için yazdıklarımızı metotlaştırmak için yazdıklarımıza sağ tık yapıp hızlı eylemler ve yeniden düzenlemeye basıp yöntemi ayıkla dersek metotlaştırmış oluruz. 

        }

        //    private static void CategoryTest()
        //    {
        //        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //        foreach (var category in categoryManager.GetAll())
        //        {
        //            Console.WriteLine(category.CategoryName);
        //        }
        //    }

        //    private static void ProductTest()
        //    {
        //        ProductManager productManager = new ProductManager(new EfProductDal());

        //        var result = productManager.GetProductDetails();
        //        if (result.Success == true)
        //        {
        //            foreach (var product in productManager.GetProductDetails().Data)
        //            {
        //                Console.WriteLine(product.ProductName + "/" + product.CategoryName);


        //            }

        //        }
        //        else
        //        {
        //            Console.WriteLine(result.Message);
        //        }

        //    }
        //}
    }
}