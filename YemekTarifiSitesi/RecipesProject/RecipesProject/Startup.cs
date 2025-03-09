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

            //APÝlerde isteklere karþýlýk verme diyelim
            services.AddHttpClient();
            //CQRS Handllarýn controllerda çalýþmasý için yapýlacak yapýlandýrmalar
            services.AddScoped<GetAllTeamQueryHandler>();
            services.AddScoped<Context>();//contextide baðýmlýlýklarýndan kurtarýyoz
            services.AddScoped<CreateTeamCommandHandler>();
            services.AddScoped<GetTeamByIdQueryHandler>();
            services.AddScoped<UpdateTeamCommandHandler>();
            services.AddScoped<DeleteTeamCommandHandler>();
            //------------------------------------------
            services.AddControllersWithViews();
            //automapper kullanýmý
            services.AddAutoMapper(typeof(Startup));
            //Validasyon iþlemleri automapper
            //birden fazla transietleri burda yazmaktansa
            //busines içerisindeki container-extensions içerisinde
            //hepsini topladým
            services.CustomerValidator();
            //businestaki servicelerime baðlý olarak gerekli crud iþlemlerini
            //yaparken newlemelerden kaçýnmak için burda çaðýrýyorum
            services.ContainerDependencies();
            //validasyon mesajlarýmý almam için kullanmam gerek
            services.AddControllersWithViews().AddFluentValidation();
            //Identity iþlemleri
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<Context>();
            //Proje seviyesinde authorization iþlemi
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //Authentice olmayan kullanýcýyý yönlendireceði yerdir.
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

            //authentication iþlemleri için Mutlaka yaz sisteme
            //authentice olan kullanýcýlarý getiremessin. useAuthorization üstünde
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
