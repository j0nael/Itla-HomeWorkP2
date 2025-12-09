using FluentValidation;
using tallermecanico.infretruture.Model;

public class InvoiceValidator : AbstractValidator<InvoiceModel>
{
    public InvoiceValidator()
    {
        // ==== CustomerId ====
        RuleFor(x => x.CustomerId)
            .GreaterThan(0)
            .WithMessage("El ID del cliente debe ser válido.");

        // ==== SellerId ====
        RuleFor(x => x.SellerId)
            .GreaterThan(0)
            .WithMessage("El ID del vendedor debe ser válido.");

        // ==== Date ====
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("La fecha de la factura no puede ser en el futuro.");

        // ==== Sales ====
        RuleFor(x => x.Sales)
            .NotNull()
            .WithMessage("La lista de ventas no puede ser nula.");

        RuleForEach(x => x.Sales)
            .NotNull()
            .WithMessage("Cada venta debe ser válida.");

    
        // ==== Repairs ====
        RuleFor(x => x.Repairs)
            .NotNull()
            .WithMessage("La lista de reparaciones no puede ser nula.");

        RuleForEach(x => x.Repairs)
            .NotNull()
            .WithMessage("Cada reparación debe ser válida.");
    }
}
