using Microsoft.EntityFrameworkCore;
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
    public class CustomerRepositorie: Baserepositorie<CustomerModel>

    {
        
        public CustomerRepositorie(CrudAPIContex contex) : base(contex)
        {
          
        }

    }
}