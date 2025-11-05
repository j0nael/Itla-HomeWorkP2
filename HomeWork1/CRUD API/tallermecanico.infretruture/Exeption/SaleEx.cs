using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallermecanico.infretruture.Exeption
{
    internal class saleEx: Exception
    {
        public saleEx()
        {
        }
        public saleEx(string? message) : base(message)
        {
        }
        public saleEx(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
