using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.Core;
using tallermecanico.infretruture.DBContex;
using tallermecanico.infretruture.Model;

namespace tallermecanico.infretruture.Repositories
{
    public class InvoiceRepositorie:Baserepositorie<InvoiceModel>
    {
        public InvoiceRepositorie(CrudAPIContex context) : base(context)
        {
        }
    }
}
