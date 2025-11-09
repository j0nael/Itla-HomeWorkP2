using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallermecanico.infretruture.Exeption
{
    public class InvoiceEX: Exception
    {
        public InvoiceEX(string message) : base(message)
        {
        }
    }
}
