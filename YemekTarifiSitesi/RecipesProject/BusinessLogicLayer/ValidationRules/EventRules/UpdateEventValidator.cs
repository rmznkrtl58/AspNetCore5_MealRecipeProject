using DTOLayer.DTOs.EventDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.EventRules
{
   public class UpdateEventValidator:AbstractValidator<UpdateEventDTO>
    {
        public UpdateEventValidator()
        {
            RuleFor(x => x.Item1).NotEmpty().WithMessage("Madde 1 Boş Bırakılamaz!");
            RuleFor(x => x.Item2).NotEmpty().WithMessage("Madde 2 Boş Bırakılamaz!");
            RuleFor(x => x.Item3).NotEmpty().WithMessage("Madde 3 Boş Bırakılamaz!");
            RuleFor(x => x.SubDescription).NotEmpty().WithMessage("Kısa Açıklama Boş Bırakılamaz!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Bilgisi Boş Bırakılamaz!");
            RuleFor(x => x.MainHeader).NotEmpty().WithMessage("Ana Başlık Boş Bırakılamaz!");
            RuleFor(x => x.MainHeader).MinimumLength(5).WithMessage("Ana Başlık En Az 5 Karakter Olmalı!");
            RuleFor(x => x.MainHeader).MaximumLength(50).WithMessage("Ana Başlık En Fazla 50 Karakter Olmalı!");
        }
    }
}
