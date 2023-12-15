using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        //List<Product> yerine IResult koyarsak bu sefer dataları döndüremeyiz.
        //Bunun yerine IDataResult yapısı kurup onu yazarız.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<Product>> GetProductDetails();
        IResult Add(Product product);
        IDataResult<List<Product>> GetById(int productId);
        IResult Update(Product product);
    }
}
