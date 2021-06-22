using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Commands.UpdateBreedCommand
{
    public class UpdateBreedCommandValidator : AbstractValidator<UpdateBreedCommand>
    {
        public UpdateBreedCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Debe ingresar un valor para la propiedad Nombre")
                .MaximumLength(20)
                .WithMessage("El Nombre no debe tener mas de {MaxLength} caracteres");
        }
    }
}
