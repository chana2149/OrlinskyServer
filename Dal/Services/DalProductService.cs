using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalProductService:IDalProducts
    {
        IDalProductsMain iDalProductsMain;
        dbcontext dbcontext;
        public DalProductService(dbcontext data , IDalProductsMain p)
        {
            dbcontext = data;
            this.iDalProductsMain = p;
        }
        public List<Product> Get()
        {
            return dbcontext.Products/*.Include(x => x.ProductsMains).ThenInclude(x => x.IdProductNavigation)*/.Include(x => x.ProductsMains).ThenInclude(x=>x.IdSnifNavigation).Include(x=>x.IdCattegoryNavigation).ToList();
        }
        public void Create(Product c)
        {
            dbcontext.Products.Add(c);
            dbcontext.SaveChanges();
        }
        public List<Product> GetByCattegory(int cattegory)
        {
            return Get().Where(p=>p.IdCattegory== cattegory).ToList();
        }

        public Product? GetById(int id)
        {
            var p = Get().Find(o => o.Id == id) ?? null;
            for (int i = 0; i < p.ProductsMains.Count; i++)
            {
                if (p.ProductsMains.ToList()[i].DayTaken<DateTime.Now)
                    
                {
                    iDalProductsMain.Update(p.ProductsMains.ToList()[i].Id);
                }
            }
             p = Get().Find(o => o.Id == id) ?? null;
             p.ProductsMains= p.ProductsMains.Where(x => x.CanBeUsed == true).ToList();
           return p;
        }
        public void Update(Product p1)
        {
            Product? p = Get().Find(s => s.Id == p1.Id);
            if (p != null)
            {

                p.Url = p1.Name;
                p.Details = p1.Details;
                p.Name = p1.Name;
                p.IdCattegory = p1.IdCattegory;
            }
            dbcontext.SaveChanges();
        }
    }
}
