using FluentValidation;
using tallermecanico.infretruture.Model;

namespace tallermecanico.aplication.Validation
{
    public class ValidationVehicle : AbstractValidator<VehicleModel>
    {
        public ValidationVehicle()
        {
            RuleFor(v => v.LicensePlate)
                .NotEmpty().WithMessage("La placa es obligatoria.")
                .MaximumLength(20).WithMessage("La placa no puede superar los 20 caracteres.");

            RuleFor(v => v.Brand)
                .NotEmpty().WithMessage("La marca es obligatoria.")
                .MaximumLength(255).WithMessage("La marca no puede superar los 255 caracteres.");

            RuleFor(v => v.Model)
                .NotEmpty().WithMessage("El modelo es obligatorio.")
                .MaximumLength(255).WithMessage("El modelo no puede superar los 255 caracteres.");

            RuleFor(v => v.Color)
                .NotEmpty().WithMessage("El color es obligatorio.")
                .MaximumLength(100).WithMessage("El color no puede superar los 100 caracteres.");

            RuleFor(v => v.Year)
                .NotEmpty().WithMessage("El año es obligatorio.")
                .InclusiveBetween(1950, DateTime.Now.Year)
                .WithMessage($"El año debe estar entre 1950 y {DateTime.Now.Year}.");

            RuleFor(v => v.CustomerId)
                .GreaterThan(0).WithMessage("Debe asignarse un cliente válido.");
        }
    }
}
