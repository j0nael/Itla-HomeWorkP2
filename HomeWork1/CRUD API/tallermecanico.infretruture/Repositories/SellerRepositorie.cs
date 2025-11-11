using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.Core;
using tallermecanico.infretruture.DBContex;

namespace tallermecanico.infretruture.Repositories
{
    public class SellerRepositorie:Baserepositorie <SellerRepositorie>
    {
        public SellerRepositorie(CrudAPIContex contex) : base(contex)
        {
        }
    }
}
