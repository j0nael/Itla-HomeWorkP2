using FluentValidation;
using tallermecanico.infretruture.Model;

namespace tallermecanico.aplication.Validation
{
    public class ValidationRepair : AbstractValidator<RepairModel>
    {
        public ValidationRepair()
        {
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede superar los 500 caracteres.");

            RuleFor(r => r.Cost)
                .GreaterThan(0).WithMessage("El costo debe ser mayor que 0.");

            RuleFor(r => r.VehicleId)
                .GreaterThan(0).WithMessage("Debe asignarse un vehículo válido.");

            RuleFor(r => r.MechanicId)
                .GreaterThan(0).WithMessage("Debe asignarse un mecánico válido.");

   

            RuleFor(r => r.Date)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("La fecha de la reparación no puede ser futura.");
        }
    }
}
