using Autofac;
using Autofac.Extras.DynamicProxy;
using Businnes.Abstract;
using Businnes.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        //uygulama ayağa kalktığında burası çalışacak.
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//API deki startup un karşılığı 
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();//API deki startup un karşılığı 
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //product, category,user, auth gibi olanlar bizim northwind de kullanacağımız yapılar.
            //tüm projede kullancağımız injectionları core katmanında bağımlılıklarını yönetiriz. 

            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>(); 
            //bu kısmı startup da entegre etmemiz gerekiyor. ayrıca core da da olmalı




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
