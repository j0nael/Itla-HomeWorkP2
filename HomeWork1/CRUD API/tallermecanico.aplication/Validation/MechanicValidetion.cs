using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using tallermecanico.infretruture.DBContex;
using tallermecanico.infretruture.Model;
namespace tallermecanico.aplication.Validation
{
    public class MechanicValidetion:AbstractValidator<MechanicModel>
    {
        private readonly CrudAPIContex _context;

        public MechanicValidetion(CrudAPIContex contex)
        {
            _context = contex;
            RuleFor(m => m.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres.");
            RuleFor(m => m.Specialty)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(255).WithMessage("El apellido no puede superar los 255 caracteres.");
       
        }
    }
}
