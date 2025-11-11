using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallermecanico.infretruture.Exeption
{
    internal class RepairEx: Exception
    {
        public RepairEx()
        {
        }
        public RepairEx(string? message) : base(message)
        {
        }
        public RepairEx(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
