using APIBack.DTOs;
using FluentValidation;

namespace APIBack.Validators
{
    public class PostEmpleadoDTOValidator : AbstractValidator<PostEmpleadoDTO>
    {
        public PostEmpleadoDTOValidator()
        {
            //Debe ser numerico
            RuleFor(x => x.DNI)
                .NotEmpty()
                .NotNull()
                .Matches("^[0-9]*$")
                //.Must(x => int.TryParse(x, out var inte))
                .MinimumLength(5).WithMessage("Debe tener mínimo 5 caracteres")
                ;
            /*RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5)
            .Length(32)
            .Must(x => Guid.TryParse(x, out var guid))
            .WithMessage("El formato de ID debe ser de tipo Guid");
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("El largo debe ser mayor a 5")
                ;
            RuleFor(x => x.LastName).NotEmpty().NotNull().Length(1, 50);
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();*/
        }
    }
}
