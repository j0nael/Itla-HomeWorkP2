
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace tallermecanico.infretruture.Model
{

    public class MechanicModel
    {
        [Key]
        public int MechanicId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; }

        // Navegación: Un mecánico realiza múltiples reparaciones
        public virtual ICollection<RepairModel> Repairs { get; set; } = new List<RepairModel>();

        public MechanicModel() { }

        public MechanicModel(string firstName, string specialty)
        {
            FirstName = firstName;
            Specialty = specialty;
        }
    }
}