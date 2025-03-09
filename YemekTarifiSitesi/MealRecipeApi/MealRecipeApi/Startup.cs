using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealRecipeApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MealRecipeApi", Version = "v1" });
            });

            //cors kullanýmý
            //Apilerimi herhangi bir kaynaktan eriþim veya herhangi bir içerik tarafýndan
            //(json,xml,html,text)gibi vasýtalarla çekmek gibi
            //ilgili core projemde consume etmek için kullanacaðým için bu yapýlandýrmayý
            //yapýyorum baþka projenin ui'nda çekerkende onun startupunu yapýlandýrman gerek
            services.AddCors(opt =>
            {
                opt.AddPolicy("MealRecipeApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MealRecipeApi v1"));
            }

            app.UseRouting();

            //cors kullanýmý
            app.UseCors("MealRecipeApiCors");//configure servis içerisindeki
            //cors yapýlandýrmamda tanýmlamýþ olduðum yapýyý burda kullandým.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
