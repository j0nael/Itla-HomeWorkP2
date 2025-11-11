using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.Core;
using tallermecanico.infretruture.DBContex;

namespace tallermecanico.infretruture.Repositories
{
    public class SaleDetailsRepositorie:Baserepositorie<SaleDetailsRepositorie>
    {
        public SaleDetailsRepositorie(CrudAPIContex contex) : base(contex)
        {
        }
    }
}
