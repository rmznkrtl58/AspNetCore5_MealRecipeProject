using DTOLayer.DTOs.MealDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.MealValidationRules
{
    public class InsertMealValidator:AbstractValidator<InsertMealDTO>
    {
        public InsertMealValidator()
        {
            RuleFor(x => x.MealName).NotEmpty().WithMessage("Yemeğin İsmi Boş Bırakılamaz!");
            RuleFor(x => x.MainHeader).NotEmpty().WithMessage("Yemeğin Başlığı Boş Bırakılamaz!");
            RuleFor(x=>x.ShortDescription).NotEmpty().WithMessage("Yemeğin Kısa Açıklaması Boş Bırakılamaz!");
            RuleFor(x=>x.LongDescription).NotEmpty().WithMessage("Yemeğin Uzun Açıklaması Boş Bırakılamaz!");
            RuleFor(x => x.ShortDescription).MinimumLength(50).WithMessage("Yemeğin Kısa Açıklaması En Az 50 Karakter Olmalı!");
            RuleFor(x => x.ShortDescription).MaximumLength(300).WithMessage("Yemeğin Kısa Açıklaması En Fazla 300 Karakter Olmalı!");
            RuleFor(x => x.LongDescription).MinimumLength(200).WithMessage("Yemeğin Uzun Açıklaması En Az 200 Karakter Olmalı!");
            RuleFor(x => x.LongDescription).MaximumLength(700).WithMessage("Yemeğin Uzun Açıklaması En Fazla 700 Karakter Olmalı!");
        }
    }
}
