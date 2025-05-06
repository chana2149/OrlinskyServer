using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.Models;
using System.Threading.Tasks;
using Dal.Api;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalOrderDetailService : IDalOrderDetail
    {
        dbcontext dbcontext;
        public DalOrderDetailService(dbcontext data)
        {
            dbcontext = data;
        }

        public void Create(OrderDetail o)
        {
            // if(o.IdProductSpecifics .Count()==0 )

            dbcontext.OrderDetails.Add(o);

            // dbcontext.OrderDetails.Add(new OrderDetail() { IdOrder = dbcontext.Orders.OrderBy(o1 => o1.IdOrder).Last().IdOrder, IdProductSpecific = o.OrderDetails.First().IdProductSpecific });

            dbcontext.SaveChanges();



        }


    }
}
