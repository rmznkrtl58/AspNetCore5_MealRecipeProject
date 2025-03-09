using DTOLayer.DTOs.AboutDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.AboutValidationRules
{
    public class AboutUpdateValidator:AbstractValidator<AboutUpdateDTO>
    {
        public AboutUpdateValidator()
        {
            RuleFor(x => x.TopHeader).NotEmpty().WithMessage("Ana başlığı boş bırakmayın");
            RuleFor(x => x.SubHeader).NotEmpty().WithMessage("Alt başlığı boş bırakmayın");
            RuleFor(x => x.Item1).NotEmpty().WithMessage("Madde 1'i boş bırakmayın");
            RuleFor(x => x.Item2).NotEmpty().WithMessage("Madde 1'yi boş bırakmayın");
            RuleFor(x => x.Item3).NotEmpty().WithMessage("Madde 3'ü boş bırakmayın");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı boş bırakmayın");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim Url'ni boş bırakmayın");
        }
    }
}
