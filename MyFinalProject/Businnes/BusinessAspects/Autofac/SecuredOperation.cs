using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Businnes.Constants;

namespace Businnes.BusinessAspects.Autofac
{
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//attribute da rolleri virgül ile ayırarak yazıyor. Bizde Split methodunu kullanarak virgül ile ayırıyoruz.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //serviceTool, bizim injection altyapımızı aynen okuyabilmemizi sağlayan bir araçtır.
            //.net in service lerini al ve onları build et.
            //Kısaca bu kod webAPI de ya da autofac de oluşturduğumuz injectionları oluşturabilmemizi sağlıyor.
        
        
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
