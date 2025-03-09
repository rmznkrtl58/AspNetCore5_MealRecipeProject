using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MealDTOs
{
   public class UpdateMealDTO
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string MainHeader { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string MealImage { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
