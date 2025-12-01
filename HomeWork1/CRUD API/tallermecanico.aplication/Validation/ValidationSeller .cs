using FluentValidation;
using tallermecanico.infretruture.Model;

namespace tallermecanico.aplication.Validation
{
    public class ValidationSeller : AbstractValidator<SellerModel>
    {
        public ValidationSeller()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("El nombre del vendedor es obligatorio.")
                .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres.");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("El apellido del vendedor es obligatorio.")
                .MaximumLength(255).WithMessage("El apellido no puede superar los 255 caracteres.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("Debe ingresar un correo válido.")
                .MaximumLength(255).WithMessage("El correo no puede superar los 255 caracteres.");

            RuleFor(s => s.PhoneNumber)
                .NotEmpty().WithMessage("El número de teléfono es obligatorio.")
                .MaximumLength(12).WithMessage("El número no puede superar los 12 caracteres.");
        }
    }
}
