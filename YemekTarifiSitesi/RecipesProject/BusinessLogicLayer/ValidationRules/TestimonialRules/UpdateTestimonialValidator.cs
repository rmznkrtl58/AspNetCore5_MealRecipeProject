using DTOLayer.DTOs.TestimonialDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.TestimonialRules
{
    public class UpdateTestimonialValidator:AbstractValidator<UpdateTestimonialDTO>
    {
        public UpdateTestimonialValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Alanını Boş Bırakmayınız!");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Meslek Alanını Boş Bırakmayınız!");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad Alanını Boş Bırakmayınız!");
            RuleFor(x => x.Message).MinimumLength(30).WithMessage("Mesajlar En Az 30 Karakter Olmalı!");
            RuleFor(x => x.Message).MaximumLength(400).WithMessage("Mesajlar En Fazla 400 Karakter Olmalı!");
        }
    }
}
