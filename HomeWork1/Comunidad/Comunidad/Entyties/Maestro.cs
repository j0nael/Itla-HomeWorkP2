using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public class Maestro : Docente
    {
        public string Nivel { get; set; }

        public string Materia { get; set; }

        public int AñosExperiencia { get; set; }

       public Maestro() { }

        public Maestro(int id, string name, int edad, string email, string puesto, string asignatura, string nivel, string materia,string direccio, int añosExperiencia,decimal salario)
        {
            this.Id = id;
            this.Nombre = name;
            this.Edad = edad;
            this.Email = email;
            this.Puesto = puesto;
            this.Asignatura = asignatura;
            this.Nivel = nivel;
            this.Materia = materia;
            this.AñosExperiencia = añosExperiencia;
            this.Salario = salario;
            this.Direccion = direccio;
        }

        public void MostrarInfo()
        {
            Console.WriteLine( $"Maestro: {Nombre}, Edad: {Edad}, Email: {Email}, Puesto: {Puesto}, Asignatura: {Asignatura}, Nivel: {Nivel}, Materia: {Materia}, Años de Experiencia: {AñosExperiencia}, Salario: {Salario}, Direccion: {Direccion}");
        }
    }

}
