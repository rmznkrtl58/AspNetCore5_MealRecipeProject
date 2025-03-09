using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.CategoryDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.ContactUsDTOs;
using DTOLayer.DTOs.EventDTOs;
using DTOLayer.DTOs.MealDTOs;
using DTOLayer.DTOs.MessageDTOs;
using DTOLayer.DTOs.RoleDTOs;
using DTOLayer.DTOs.TeamDTOs;
using DTOLayer.DTOs.TestimonialDTOs;
using DTOLayer.DTOs.UserDTOs;
using DTOLayer.DTOs.WhyUsDTOs;
using EntityLayer.Concrete;

namespace RecipesProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AboutListDto, About>().ReverseMap();
            CreateMap<WhyUsListDTO, WhyUs>().ReverseMap();
            CreateMap<MealListDTO,Meal>().ReverseMap();
            CreateMap<EventListDTO, Event>().ReverseMap();
            CreateMap<TestimonialListDto,Testimonial>().ReverseMap();
            CreateMap<MealImageListDTO, Meal>().ReverseMap();
            CreateMap<TeamListDTO, Team>().ReverseMap();
            CreateMap<AboutUpdateDTO,About>().ReverseMap();
            CreateMap<WhyUsUpdateDTO, WhyUs>().ReverseMap();
            CreateMap<WhyUsInsertDTO, WhyUs>().ReverseMap();
            CreateMap<InsertMealDTO, Meal>().ReverseMap();
            CreateMap<UpdateMealDTO, Meal>().ReverseMap();
            CreateMap<InsertEventDTO, Event>().ReverseMap();
            CreateMap<UpdateEventDTO,Event>().ReverseMap();
            CreateMap<AddTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDTO,Testimonial>().ReverseMap();
            CreateMap<CategoryListDTO, Category>().ReverseMap();
            CreateMap<AddCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<RegisterUserDTO, AppUser>().ReverseMap();
            CreateMap<UpdateUserDTO, AppUser>().ReverseMap();
            CreateMap<CreateRoleDTO,AppRole>().ReverseMap();
            CreateMap<UpdateRoleDTO, AppRole>().ReverseMap();
            CreateMap<AssignUserRoleDTO, AppRole>().ReverseMap();
            CreateMap<ListMessageDTO,Message>().ReverseMap();
            CreateMap<MessageDetailsDTO, Message>().ReverseMap();
            CreateMap<SendMessageDTO, Message>().ReverseMap();
            CreateMap<ContactListDTO,Contact>().ReverseMap();
            CreateMap<ListContactUsDTO, ContactUs>().ReverseMap();
        }
    }
}
