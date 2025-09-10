using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public class Administrador : Docente
    {
        public string Area { get; set; }

        public Administrador() { }

        public Administrador(int id, string name, int edad, string email, string puesto, string asignatura, string area, decimal salario, string numerotelefono, string direcion)
        {
            this.Id = id;
            this.Nombre = name;
            this.Edad = edad;
            this.Email = email;
            this.Puesto = puesto;
            this.Asignatura = asignatura;
            this.Area = area;
            this.Salario = salario;
            this.Telefono = numerotelefono;
            this.Direccion = direcion;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Maestro: {Nombre}, Edad: {Edad}, Email: {Email}, Puesto: {Puesto}, Asignatura: {Asignatura},Salario: {Salario}, Direccion: {Direccion}");
        }


    }

}
