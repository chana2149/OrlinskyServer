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
    public class DalOrderService : IDalOrder
    {
        dbcontext dbcontext;
        public DalOrderService(dbcontext data)
        {
            dbcontext = data;
        }

        public void Create(Order o)
        {
            // if(o.IdProductSpecifics .Count()==0 )

            // dbcontext.Orders.Add(o);

            //// dbcontext.OrderDetails.Add(new OrderDetail() { IdOrder = dbcontext.Orders.OrderBy(o1 => o1.IdOrder).Last().IdOrder, IdProductSpecific = o.OrderDetails.First().IdProductSpecific });

            // dbcontext.SaveChanges();

         
               
            dbcontext.Orders.Add(o);
            dbcontext.SaveChanges();

            //dbcontext.Orders.OrderBy(o=>o.IdOrder).Last().IdProductSpecifics.Add(new ProductsMain() { Id = 1002 });

            // dbcontext.SaveChanges();

        }

        public List<Order> GetAll()
        {   //GetAllOrder();
            return dbcontext.Orders.Include(x => x.OrderDetails).ThenInclude(o=>o.IdProductSpecificNavigation).ThenInclude(i=>i.IdProductNavigation).ToList();
            
        }

        //public List<OrderDetail> GetAllOrder()
        //{
        //    return dbcontext.OrderDetails.Include(x => x.IdProductSpecificNavigation ).ToList();
        //}

        public List<Order> GetByIdCustomer(string id)
        {
            return GetAll().Where(o=>o.IdCostumer==id).ToList();
        }
      

    }
}
