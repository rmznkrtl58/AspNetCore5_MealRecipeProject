using DTOLayer.DTOs.WhyUsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.WhyUsValidationRules
{
    public class WhyUsInsertValidator:AbstractValidator<WhyUsInsertDTO>
    {
        public WhyUsInsertValidator()
        {
            RuleFor(x => x.MainHeader).NotEmpty().WithMessage("Ana Başlık Kısmı Boş Bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
        }
    }
}
