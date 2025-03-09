using DTOLayer.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules.UserValidationRules
{
  public class RegisterValidator:AbstractValidator<RegisterUserDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("Kullanıcı Adını Boş Bırakmayınız!");
            RuleFor(x => x.mail).NotEmpty().WithMessage("E-Posta Adresini Boş Bırakmayınız!");
            RuleFor(x => x.password).NotEmpty().WithMessage("Şifrenizi Boş Bırakmayınız!");
            RuleFor(x => x.name).NotEmpty().WithMessage("Adınızı Boş Bırakmayınız!");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Soyadınızı Boş Bırakmayınız!");
            RuleFor(x => x.password).Equal(x=>x.confirmPassword).WithMessage("Şifreler Eşleşmiyor!");
            RuleFor(x => x.name).MinimumLength(2).WithMessage("Adınız En Az 2 Karakter Olmalı!");
            RuleFor(x => x.name).MaximumLength(25).WithMessage("Adınız En Fazla 25 Karakter Olmalı!");
            RuleFor(x => x.surname).MaximumLength(25).WithMessage("Soyadınız En Fazla 25 Karakter Olmalı!");
            RuleFor(x => x.surname).MinimumLength(3).WithMessage("Soyadınız En Az 3 Karakter Olmalı!");
        }
    }
}
