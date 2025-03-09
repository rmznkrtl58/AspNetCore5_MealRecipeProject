using BusinessLogicLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipesProject.CQRS.Handlers.TeamHandlers;
using System.Linq;


namespace RecipesProject
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

            //AP�lerde isteklere kar��l�k verme diyelim
            services.AddHttpClient();
            //CQRS Handllar�n controllerda �al��mas� i�in yap�lacak yap�land�rmalar
            services.AddScoped<GetAllTeamQueryHandler>();
            services.AddScoped<Context>();//contextide ba��ml�l�klar�ndan kurtar�yoz
            services.AddScoped<CreateTeamCommandHandler>();
            services.AddScoped<GetTeamByIdQueryHandler>();
            services.AddScoped<UpdateTeamCommandHandler>();
            services.AddScoped<DeleteTeamCommandHandler>();
            //------------------------------------------
            services.AddControllersWithViews();
            //automapper kullan�m�
            services.AddAutoMapper(typeof(Startup));
            //Validasyon i�lemleri automapper
            //birden fazla transietleri burda yazmaktansa
            //busines i�erisindeki container-extensions i�erisinde
            //hepsini toplad�m
            services.CustomerValidator();
            //businestaki servicelerime ba�l� olarak gerekli crud i�lemlerini
            //yaparken newlemelerden ka��nmak i�in burda �a��r�yorum
            services.ContainerDependencies();
            //validasyon mesajlar�m� almam i�in kullanmam gerek
            services.AddControllersWithViews().AddFluentValidation();
            //Identity i�lemleri
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<Context>();
            //Proje seviyesinde authorization i�lemi
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //Authentice olmayan kullan�c�y� y�nlendirece�i yerdir.
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index/";
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //authentication i�lemleri i�in Mutlaka yaz sisteme
            //authentice olan kullan�c�lar� getiremessin. useAuthorization �st�nde
            //olacak
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
