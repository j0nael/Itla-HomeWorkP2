using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using tallermecanico.infretruture.Model;
using tallermecanico.infretruture.DBContex;

namespace tallermecanico.aplication.Validation
{
    public class ValidationCustomer: AbstractValidator<CustomerModel>
    {
        private readonly CrudAPIContex _context;
        public ValidationCustomer(CrudAPIContex contex) 
        { 
            _context = contex;
         
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres.");
            RuleFor(c => c.LastName) 
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(255).WithMessage("El apellido no puede superar los 255 caracteres.");
            RuleFor(c => c.PhoneNumber) 
                                .NotEmpty().WithMessage("El numero de telefono es obligatorio.")
                .MaximumLength(12).WithMessage("El numero de telefono no puede superar los 12 caracteres.");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("El Email es obligatorio.")
                .MaximumLength(255).WithMessage("El email no puede superar los 255 caracteres.");

        
        }

        



    }
}
