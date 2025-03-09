using DTOLayer.DTOs.WhyUsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.WhyUsValidationRules
{
    public class WhyUsUpdateValidator:AbstractValidator<WhyUsUpdateDTO>
    {
        public WhyUsUpdateValidator()
        {
            RuleFor(x => x.MainHeader).NotEmpty().WithMessage("Ana Başlığı Boş Bırakmayınız.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı Boş Bırakmayınız.");
            RuleFor(x => x.Description).MinimumLength(15).WithMessage("Açıklama Minimum 15 karakter olmalı!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama Maximum 500 karakter olmalı!");
        }
    }
}
