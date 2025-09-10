
/**************************************************
 * Proyecto: Comunidad
 * Autor: Jonathan Geraldo
 * Matrícula: 20242604
 * Fecha: 10/09/2023
 * Descripción: Programa principal para gestionar una comunidad educativa.
 **************************************************/

using Comunidadv2.Entyties;

namespace Comunidadv2
{
    class Program
    {
        public static void Main()
        {
            Estudiante estudiante1 = new Estudiante(1,"Jonathan geraldo",24,"fulano@","10/09/2015", "fenix","10/10/1000","3452456","Calle fulano");

            Console.WriteLine("Informacion del Estudiante:");
            estudiante1.MostrarInfo();

            Console.WriteLine();


            ExAlumno exAlumno = new ExAlumno(1, "Jonathan geraldo", 24, "fulano@", "10/09/2015", "fenix", "10/10/1000", "3452456", "Calle fulano");

            Console.WriteLine("Informacion del ExAlumno:");
            exAlumno.MostrarInfo();

            Console.WriteLine();

            Maestro maestro1 = new Maestro();
            maestro1.Id = 1;    
            maestro1.Nombre = "Juan Perez";
            maestro1.Edad = 45;
            maestro1.Email = "calle pedro";
            maestro1.Telefono = "123456789";
            maestro1.Direccion = "Calle Maestro 123";
            maestro1.Materia = "Matematicas";
            maestro1.AñosExperiencia = 20;
            Console.WriteLine("Informacion del Maestro:");
            maestro1.MostrarInfo();

            Console.WriteLine();


            Empleado empleado1 = new Empleado();
            empleado1.Id = 1;
            empleado1.Nombre = "Maria Lopez";
            empleado1.Edad = 30;
            empleado1.Email = "marciano@";
            empleado1.Telefono = "987654321";
            empleado1.Direccion = "Calle Empleado 456";
            empleado1.Puesto = "Administrador";
            empleado1.Salario = 3000.50m;
            Console.WriteLine("Informacion del Empleado:");
            empleado1.MostrarInfo();

            Console.WriteLine();


            Docente docente1 = new Docente();
            docente1.Id = 2;
            docente1.Nombre = "Ana Gomez";
            docente1.Edad = 35;
            docente1.Email = "ana@";

            docente1.Telefono = "555555555";
            docente1.Direccion = "Calle Docente 789";
            docente1.Asignatura = "Ciencias";
            docente1.Salario = 2500.75m;
            Console.WriteLine("Informacion del Docente:");
            docente1.MostrarInfo();

            Console.WriteLine();


            Administrativo administrativo1 = new Administrativo();
            administrativo1.Id = 3;
            administrativo1.Nombre = "Luis Martinez";
            administrativo1.Edad = 40;
            administrativo1.Email = "luis@";
            administrativo1.Telefono = "444444444";
            administrativo1.Direccion = "Calle Administrativo 101";
            administrativo1.Puesto = "Secretario";
            administrativo1.Departamento = "Recursos Humanos";
            administrativo1.Salario = 2800.00m;
            Console.WriteLine("Informacion del Administrativo:");
            administrativo1.MostrarInfo();

            Console.WriteLine();


            Administrador administrador = new Administrador();
            administrador.Id = 1;
            administrador.Nombre = "Carlos Sanchez";
            administrador.Edad = 50;
            administrador.Email = "carlos@";
            administrador.Telefono = "333333333";
            administrador.Direccion = "Calle Administrador 202";
            administrador.Puesto = "Director";
            administrador.Salario = 5000.00m;
            Console.WriteLine("Informacion del Administrador:");
            administrador.MostrarInfo();

       Console.ReadKey();











        }
    }
}