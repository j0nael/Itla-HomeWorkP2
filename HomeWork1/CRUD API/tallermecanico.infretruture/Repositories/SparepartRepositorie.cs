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
    public class SparepartRepositorie:Baserepositorie<SparePartModel>
    {
        public SparepartRepositorie(CrudAPIContex contex) : base(contex)
        {
        }
    }
}
