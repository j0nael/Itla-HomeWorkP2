using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallermecanico.infretruture.Exeption
{
    internal class SparePartEx: Exception
    {
        public SparePartEx(string message) : base(message)
        {
        }
    }
}
