using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunidadv2.Entyties
{
    public class MiembroDeLaComunidad : Persona
    {

        public void MostrarInfo()
        {
          
            Console.WriteLine($"Id: {Id}, Nombre :{Nombre},Edad :{Edad},Email : {Email},Telefono : {Telefono},Direccion :{Direccion},Salario: {Salario}");
        }
    }


}
