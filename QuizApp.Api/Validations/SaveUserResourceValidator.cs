using System;
using FluentValidation;
using QuizApp.Api.Resources;

namespace QuizApp.Api.Validations
{
	public class SaveUserResourceValidator : AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .WithMessage("Boş Geçme")
                .MaximumLength(50)
                .WithMessage("Max 50 karakter içerebilir.");
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Boş Geçme")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi girin.");
        }
    }
}

