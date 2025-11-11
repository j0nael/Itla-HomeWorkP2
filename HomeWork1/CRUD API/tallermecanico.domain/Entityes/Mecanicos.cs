
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

       
    }
}