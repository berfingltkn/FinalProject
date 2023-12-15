using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac, ninject, Castlewinds, structureMap, LightInject, DryInject -->IoC container
            // Add framework services.
            services.AddControllers();
            services.AddCors();
            //services.AddSingleton<IProductService,ProductManager>();
            ////bu yap� controller a �unu diyor; e�er sen bir ba��ml�l�k g�r�rsen IProductService tipinde onun ba��ml�l��� ProductManager d�r demektir.
            //// t�m bellekte bir tane productmanager olu�turuyor. 
            //services.AddSingleton<IProductDal,EfProductDal>();

           // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           //yukar�dakini startup dan kald�r�p her projede kulland���m�z i�in core katman�nda bir yap� olu�turduk.
            
            //projemizde jwt kulland���m�z� haber veriyoruz bu kodlar ile
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,//token �n belirlenece�i hedef ya da kaynak ismi
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                       
                    };
                });

            //bu yap� sayesinde t�m sistemde �al��an ba��ml�l�klar� y�netebiliriz.
            services.AddDependenctResolvers(new ICoreModule[] { 
           new CoreModule()
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configure production-specific behavior here.
            }

            // Enable routing.
            app.UseRouting();
            
      

            app.UseCors(builder => builder.WithOrigins("http://localhost:34659").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            //asp.net ya�am d�ng�s�nde hangi yap�lar�n s�ras�yla devreye girece�ini s�yl�yoruz.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
