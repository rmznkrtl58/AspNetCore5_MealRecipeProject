﻿using DTOLayer.DTOs.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.CategoryValidationRules
{
   public class InsertCategoryValidator:AbstractValidator<AddCategoryDTO>
    {
        public InsertCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz!");
        }
    }
}
