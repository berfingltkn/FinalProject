using Businnes.Abstract;
using Businnes.BusinessAspects.Autofac;
using Businnes.Constants;
using Businnes.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Businnes;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Concrete
{
   public class ProductManager:IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]//Add methodunu doğrula productValidator daki kurallara göre
        public IResult Add(Product product)
        {
            //business codes

            //burada polymorphism yaptık. 
           IResult result= BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID),
                CheckIfProductNameExists(product.ProductName),
                CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);



            //eğer mevcut kategori sayısı 15 i geçtiyse sisteme yeni ürün eklenemez
           
           
        }

        public IDataResult<List<Product>> GetAll()
        {

            //Data Access den çağırmamız gerekiyor.
            //diyelim ki burada iş kodları var( örneğin eğer ... şartlarını sağlıyorsa gibi)

            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
                //maintenanceTime-> bakım zamanı
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
            // Data Access deki yani veritabanındaki verilerden GetAll metodunu çalıştır.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID==id));
       //categoryId, bizim gönderdiğimiz id ye eşitse listele diyoruz.

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice >= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetById(int productId)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetProductDetails()
        {
            throw new NotImplementedException();
        }

        //tekrar eden bussiness code ları yazıyoruz. Sadece burada kullandığımız için private yaptık.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}



