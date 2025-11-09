
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using tallermecanico.domain.Entityes;

namespace tallermecanico.domain.Entityes
{

    public class Mechanic
    {
        [Key]
        public int MechanicId { get; set; }
        public string FirstName { get; set; }
        public string Specialty { get; set; }

        public List<Repair>? Repairs { get; set; }

        public Mechanic(int mechanicId, string firstName, string specialty)
        {
            MechanicId = mechanicId;
            FirstName = firstName;
            Specialty = specialty;
        }

        public Mechanic() { }
    }
}