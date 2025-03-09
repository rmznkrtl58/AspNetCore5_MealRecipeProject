﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MealDTOs
{
    public class MealListDTO
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string MainHeader { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string MealImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool RecipeStatus { get; set; }

    }
}
