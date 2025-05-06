
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlOrders
    {
        List<BlOrder> GetByIdCustomer(string id);

        //List<BlOrder> GetAll();
        void Create(List<BlOrder> o);

    }
}
