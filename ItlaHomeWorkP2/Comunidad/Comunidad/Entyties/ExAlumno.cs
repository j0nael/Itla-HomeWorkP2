using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public class ExAlumno :Estudiante
    {

        public Estudiante AlumnoOriginal { get; set; }
       

        public ExAlumno() { }

        public ExAlumno(int id, string nombre, int edad, string email, string fechaGraduacion,string direcion, string promocion, string añoEgreso,string numerotelefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Email = email;
            this.FechaGraduacion = fechaGraduacion;
            this.Promocion = promocion;
            this.AñoEgreso = añoEgreso;
            this.Telefono = numerotelefono;
            this.Direccion = direcion;
           
        }

        public  void MostrarInfo()
        {
           

            Console.WriteLine($"Id: {Id}, Nombre :{Nombre},Edad :{Edad},Email : {Email},Telefono : {Telefono},Direccion :{Direccion}, Fecha De Graduacion {FechaGraduacion}," +
                $"Año de egreso{AñoEgreso}");
        }
    }

}
