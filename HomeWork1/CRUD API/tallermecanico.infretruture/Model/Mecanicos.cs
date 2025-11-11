
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace tallermecanico.infretruture.Model
{

    public class MechanicModel
    {
        [Key]
        public int MechanicId { get; set; }
        public string FirstName { get; set; }
        public string Specialty { get; set; }

        public List<RepairModel>? Repairs { get; set; }

        public MechanicModel(int mechanicId, string firstName, string specialty)
        {
            MechanicId = mechanicId;
            FirstName = firstName;
            Specialty = specialty;
        }

        public MechanicModel() { }
    }
}