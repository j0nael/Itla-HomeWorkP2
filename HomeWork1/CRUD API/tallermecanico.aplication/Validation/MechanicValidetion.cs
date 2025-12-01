using FluentValidation;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.DBContex;

namespace tallermecanico.aplication.Validation
{
    public class ValidationMechanic : AbstractValidator<MechanicModel>
    {
        private readonly CrudAPIContex _context;

        public ValidationMechanic(CrudAPIContex context)
        {
            _context = context;

            RuleFor(m => m.FirstName)
                .NotEmpty().WithMessage("El nombre del mecánico es obligatorio.")
                .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres.");

            RuleFor(m => m.Specialty)
                .NotEmpty().WithMessage("La especialidad es obligatoria.")
                .MaximumLength(255).WithMessage("La especialidad no puede superar los 255 caracteres.");
        }
    }
}
