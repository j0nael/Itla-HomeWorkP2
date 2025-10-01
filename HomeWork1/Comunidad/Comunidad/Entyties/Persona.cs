using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public decimal Salario { get; set; }

        public Persona() { }

        
       public Persona(int id, string name, int edad, string email, string telefono, string direccion, decimal salario)
        {
            this.Id = id;
            this.Nombre = name;
            this.Edad = edad;
            this.Email = email;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Salario = salario;
        }


       
    }

}
