using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public class Estudiante : MiembroDeLaComunidad
    {
        public string Carrera { get; set; }

        public string FechaGraduacion { get; set; }

        public string Promocion { get; set; }

        public string AñoEgreso { get; set; }
        public Estudiante()
        {
        }

        public Estudiante(int id, string name, int edad, string email, string fechaGraduacion, string direcion, string promocion, string añoEgreso, string numerotelefono)
        {
            this.Id = id;
            this.Nombre = name;
            this.Edad = edad;
            this.Email = email;
            this.FechaGraduacion = fechaGraduacion;
            this.Promocion = promocion;
            this.AñoEgreso = añoEgreso;
            this.Telefono = numerotelefono;
            this.Direccion = direcion;
        }

        public void MostrarInfo()
        {

            Console.WriteLine($"Id: {Id}, Nombre :{Nombre},Edad :{Edad},Email : {Email},Telefono : {Telefono},Direccion :{Direccion}, Fecha De Graduacion {FechaGraduacion}," +
                $"Año de egreso{AñoEgreso},Promocion : {Promocion}");
        }
    }

}
