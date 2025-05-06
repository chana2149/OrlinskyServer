using Bl;
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlOrderService : IBlOrders
    {
        IDal dal;
        IBlProductsMain p;
        public BlOrderService(IDal dal, IBlProductsMain p)
        {
            this.dal = dal;
            this.p = p;
        }

        //    public void Create(List<BlOrder> or)
        //    {

        //        foreach (var item in or)
        //        {
        //            // יצירת הזמנה חדשה
        //            Order o = new Order()
        //            {
        //                IdCostumer = item.IdCostumer,
        //                IdSnif = item.IdSnif,
        //                Totalsum = 0,
        //                Date = DateTime.Now,
        //            };

        //            // שמירת ההזמנה ללא פרטים
        //            dal.Order.Create(o);
        //            if (item.OrderDetails != null)
        //            {
        //                // הוספת פרטי הזמנה בנפרד
        //                foreach (var detail in item.OrderDetails)
        //                {
        //                    if (detail != null)
        //                    {
        //                        OrderDetail orderDetail = new OrderDetail()
        //                        {
        //                            IdOrder = o.IdOrder, // שימוש ב-ID שנוצר
        //                            IdProductSpecific = detail.IdProductSpecific
        //                        };

        //                        // הוספת פרטי הזמנה בנפרד
        //                        dal.OrderDetail.Create(orderDetail);
        //                    }
        //                }
        //            }

        //            foreach (var detail in item.OrderDetails)
        //            {
        //                dal.ProductsMain.Update(detail.IdProductSpecific);
        //            }

        //        }
        //    }






        public void Create(List<BlOrder> or)
        {
            //or.ForEach(o1=>o1.)
            foreach (var item in or)
            {
                Order o = new Order()
                {
                    IdCostumer = item.IdCostumer,
                    IdSnif = item.IdSnif,
                    IdOrder = item.IdOrder
                    //IdProductSpecifics = (ICollection<ProductsMain>)or.IdProductSpecifics
                };
                o.Totalsum = 0;
                o.Date = DateTime.Now;
                if (item.OrderDetails != null)
                {
                    item.OrderDetails.ToList().ForEach(oo =>
                    {
                        o.OrderDetails.Add(new OrderDetail()
                        {
                            IdOrder = oo.IdOrder,
                            IdProductSpecific = oo.IdProductSpecific,

                        });
                        o.Totalsum += oo.IdProductSpecificNavigation.Price;
                    });
                }
                dal.Order.Create(o);

                (item.OrderDetails.ToList()).ForEach(x => dal.ProductsMain.Update(x.IdProductSpecific));
            }
        }

        public BlProductsMain2 blProductsMain2(ProductsMain pp)
        {
            BlProductsMain2 p1 = new()
            {
                IdProduct = (int)pp.IdProduct,
                Price = pp.Price,
                IdProductNavigation = p.prodtoBlProd1(pp.IdProductNavigation)
            };
            return p1;
        }
        public List<BlOrderDetail> ordtoBlOrd(List<OrderDetail> lst)
        {

            List<BlOrderDetail> list = new();
            lst.ForEach(p => list.Add(new BlOrderDetail()
            { IdOrder = p.IdOrder, IdProductSpecific = p.IdProductSpecific, IdProductSpecificNavigation = blProductsMain2(p.IdProductSpecificNavigation) }));
            return list;
        }
        public List<BlOrder> GetByIdCustomer(string id)
        {
            var pList = dal.Order.GetByIdCustomer(id);
            List<BlOrder> list = new();
            pList.ForEach(o => list.Add(new BlOrder()
            { IdCostumer = o.IdCostumer, IdSnif = o.IdSnif, IdOrder = o.IdOrder, OrderDetails = ordtoBlOrd(o.OrderDetails.ToList()), Date = o.Date, Totalsum = o.Totalsum }));
            return list;
        }

    }
}

