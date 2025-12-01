using FluentValidation;
using tallermecanico.infretruture.DBContex;
using tallermecanico.infretruture.Model;

public class ValidationCustomer : AbstractValidator<CustomerModel>
{
    private readonly CrudAPIContex _context;

    public ValidationCustomer(CrudAPIContex context)
    {
        _context = context;

        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres.");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("El apellido es obligatorio.")
            .MaximumLength(255).WithMessage("El apellido no puede superar los 255 caracteres.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("El Email es obligatorio.")
            .MaximumLength(255).WithMessage("El email no puede superar los 255 caracteres.")
            .EmailAddress().WithMessage("Debe ingresar un correo válido.");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("El número de teléfono es obligatorio.")
            .MaximumLength(12).WithMessage("El número de teléfono no puede superar los 12 caracteres.");
    }
}
