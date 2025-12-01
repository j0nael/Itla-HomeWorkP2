using FluentValidation;
using tallermecanico.infretruture.Model;

namespace tallermecanico.aplication.Validation
{
    public class ValidationSale : AbstractValidator<SaleModel>
    {
        public ValidationSale()
        {
            RuleFor(s => s.CustomerId)
                .GreaterThan(0).WithMessage("Debe seleccionar un cliente válido.");

            RuleFor(s => s.SellerId)
                .GreaterThan(0).WithMessage("Debe seleccionar un vendedor válido.");

            RuleFor(s => s.Total)
                .GreaterThanOrEqualTo(0).WithMessage("El total no puede ser negativo.");

            RuleFor(s => s.Date)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.");
        }
    }
}
