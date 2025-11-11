using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallermecanico.infretruture.Exeption
{
    internal class SaleDetailEx: Exception
    {
        public SaleDetailEx()
        {
        }
        public SaleDetailEx(string? message) : base(message)
        {
        }
        public SaleDetailEx(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
