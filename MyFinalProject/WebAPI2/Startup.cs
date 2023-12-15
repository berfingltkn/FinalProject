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
            ////bu yapý controller a þunu diyor; eðer sen bir baðýmlýlýk görürsen IProductService tipinde onun baðýmlýlýðý ProductManager dýr demektir.
            //// tüm bellekte bir tane productmanager oluþturuyor. 
            //services.AddSingleton<IProductDal,EfProductDal>();

           // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           //yukarýdakini startup dan kaldýrýp her projede kullandýðýmýz için core katmanýnda bir yapý oluþturduk.
            
            //projemizde jwt kullandýðýmýzý haber veriyoruz bu kodlar ile
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
                        ValidAudience = tokenOptions.Audience,//token ýn belirleneceði hedef ya da kaynak ismi
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                       
                    };
                });

            //bu yapý sayesinde tüm sistemde çalýþan baðýmlýlýklarý yönetebiliriz.
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

            //asp.net yaþam döngüsünde hangi yapýlarýn sýrasýyla devreye gireceðini söylüyoruz.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
