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

            //cors kullan�m�
            //Apilerimi herhangi bir kaynaktan eri�im veya herhangi bir i�erik taraf�ndan
            //(json,xml,html,text)gibi vas�talarla �ekmek gibi
            //ilgili core projemde consume etmek i�in kullanaca��m i�in bu yap�land�rmay�
            //yap�yorum ba�ka projenin ui'nda �ekerkende onun startupunu yap�land�rman gerek
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

            //cors kullan�m�
            app.UseCors("MealRecipeApiCors");//configure servis i�erisindeki
            //cors yap�land�rmamda tan�mlam�� oldu�um yap�y� burda kulland�m.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
