﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CategoryDTOs
{
    public class CategoryListDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
