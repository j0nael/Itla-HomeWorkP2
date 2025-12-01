using FluentValidation;
using tallermecanico.infretruture.Model;

namespace tallermecanico.aplication.Validation
{
    public class ValidationSparePart : AbstractValidator<SparePartModel>
    {
        public ValidationSparePart()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("El nombre del repuesto es obligatorio.")
                .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres.");

            RuleFor(s => s.InitialQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("La cantidad inicial no puede ser negativa.");

            RuleFor(s => s.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("La cantidad actual no puede ser negativa.");

            RuleFor(s => s.UnitPrice)
                .GreaterThan(0).WithMessage("El precio unitario debe ser mayor que 0.");

            RuleFor(s => s.WholesalePrice)
                .GreaterThanOrEqualTo(0).WithMessage("El precio al por mayor debe ser mayor o igual a 0.");

            RuleFor(s => s.EntryDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de entrada no puede ser futura.");
        }
    }
}
