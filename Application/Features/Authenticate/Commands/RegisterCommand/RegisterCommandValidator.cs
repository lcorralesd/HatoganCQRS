using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .MaximumLength(30).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .MaximumLength(30).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .MaximumLength(30).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .MaximumLength(15).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .MaximumLength(15).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres")
                .Equal(x => x.Password).WithMessage("{PropertyName} debe ser igula a password");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} es requerido")
                .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de email valida")
                .MaximumLength(100).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres");
        }
    }
}
