﻿using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        //bagımlılığı azaltmak için bunu yapıyoruz.
        public CategoryManager(ICategoryDal categoryDal) {
            //constructer
            _categoryDal = categoryDal;
        }
        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
          
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryID == categoryId));
        }
    }
}
