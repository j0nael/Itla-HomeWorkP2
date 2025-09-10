using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public class Administrativo : Empleado
    {
        public string Departamento { get; set; }

        public Administrativo() { }

        public Administrativo(int id, string name, int edad, string email, string puesto, string departamento, decimal salario, string numerotelefono, string direcion)
        {
            this.Id = id;
            this.Nombre = name;
            this.Edad = edad;
            this.Email = email;
            this.Puesto = puesto;
            this.Departamento = departamento;
            this.Salario = salario;
            this.Telefono = numerotelefono;
            this.Direccion = direcion;
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"Maestro: {Nombre}, Edad: {Edad}, Email: {Email}, Puesto: {Puesto}, Salario: {Salario}, Direccion: {Direccion}");
        }


    }

}
