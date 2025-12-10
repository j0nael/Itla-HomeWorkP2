using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        // Navegación
        public virtual ICollection<RepairModel> Repairs { get; set; } = new List<RepairModel>();

        public MechanicModel() { }

        public MechanicModel(string firstName, string specialty)
        {
            FirstName = firstName;
            Specialty = specialty;
        }
    }
}