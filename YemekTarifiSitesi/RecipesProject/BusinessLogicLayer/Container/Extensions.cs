using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules.AboutValidationRules;
using BusinessLogicLayer.ValidationRules.CategoryValidationRules;
using BusinessLogicLayer.ValidationRules.EventRules;
using BusinessLogicLayer.ValidationRules.MealValidationRules;
using BusinessLogicLayer.ValidationRules.TestimonialRules;
using BusinessLogicLayer.ValidationRules.UserValidationRules;
using BusinessLogicLayer.ValidationRules.WhyUsValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.CategoryDTOs;
using DTOLayer.DTOs.EventDTOs;
using DTOLayer.DTOs.MealDTOs;
using DTOLayer.DTOs.TestimonialDTOs;
using DTOLayer.DTOs.UserDTOs;
using DTOLayer.DTOs.WhyUsDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace BusinessLogicLayer.Container
{
    public static class Extensions
    {    
        //uı tarafında entitylerimin businesa bağlı olarak servicelerini
        //çağırıp gerekli crud işlemlerini yapmasını sağlarken newleme
        //yapmadan yapacağımız için aşağıdaki yapılandırmayı yapıp
        //startupta çağıracaz
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IWhyUsDal, EfWhyUsDal>();
            services.AddScoped<IWhyUsService, WhyUsManager>();
            services.AddScoped<IMealService,MealManager>();
            services.AddScoped<IMealDal,EfMealDal>();
            services.AddScoped<IEventDal,EfEventDal>();
            services.AddScoped<IEventService,EventManager>();
            services.AddScoped<ITestimonialDal,EfTestimonialDal>();
            services.AddScoped<ITestimonialService,TestimonialManager>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITeamDal,EfTeamDal>();
            services.AddScoped<ICategoryDal,EfCategoryDal>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<IAppUserDal,EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IMessageDal,EfMessageDal>();
            services.AddScoped<IMessageService,MessageManager>();
            services.AddScoped<IContactService,ContactManager>();
            services.AddScoped<IContactDal,EfContactDal>();
            services.AddScoped<IContactUsDal,EfContactUsDal>();
            services.AddScoped<IContactUsService, ContactUsManager>();
        }


        //Dto (Auto mapper kullanımı)
        //AUTO MAPPER KULLANIMI STARTUPTAN BURAYA TAŞIDIK
        //bu olmassa validasyon yapmaz
        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AboutUpdateDTO>,AboutUpdateValidator>();
            services.AddTransient<IValidator<WhyUsUpdateDTO>, WhyUsUpdateValidator>();
            services.AddTransient<IValidator<WhyUsInsertDTO>,WhyUsInsertValidator>();
            services.AddTransient<IValidator<InsertMealDTO>,InsertMealValidator>();
            services.AddTransient<IValidator<UpdateMealDTO>,UpdateMealValidator>();
            services.AddTransient<IValidator<InsertEventDTO>, InsertEventValidator>();
            services.AddTransient<IValidator<UpdateEventDTO>, UpdateEventValidator>();
            services.AddTransient<IValidator<AddTestimonialDTO>,AddTestimonialValidator>();
            services.AddTransient<IValidator<UpdateTestimonialDTO>, UpdateTestimonialValidator>();
            services.AddTransient<IValidator<AddCategoryDTO>, InsertCategoryValidator>();
            services.AddTransient<IValidator<UpdateCategoryDTO>, UpdateCategoryValidator>();
            services.AddTransient<IValidator<RegisterUserDTO>,RegisterValidator>();
        }
    }
}
