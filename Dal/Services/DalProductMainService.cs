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
    public class DalProductMainService : IDalProductsMain
    {
        dbcontext dbcontext;
        public DalProductMainService(dbcontext data)
        {
            dbcontext = data;
        }

        //public void Create(ProductsMain pm)
        //{
        //    dbcontext.ProductsMains.Add(pm);
        //    dbcontext.SaveChanges();
        //}
        public async Task CreateAsync(ProductsMain pm)
        {
            // בדוק אם כבר קיימת ישות עם אותו מזהה
            var existingProduct = await dbcontext.ProductsMains.FindAsync(pm.Id);

            if (existingProduct != null)
            {
                // אם הישות כבר קיימת, עדכן את המאפיינים שלה
                dbcontext.Entry(existingProduct).CurrentValues.SetValues(pm);
            }
            else
            {
                // אם הישות לא קיימת, הוסף אותה
                await dbcontext.ProductsMains.AddAsync(pm);
            }

            await dbcontext.SaveChangesAsync();
        }

        public void Delete(int p)
        {
          
            ProductsMain p1 = Get().Find(x => x.Id == p);
            if(p1.Available==true)
            dbcontext.ProductsMains.Remove(p1);
            dbcontext.SaveChanges();
        }

        public List<ProductsMain> Get()
        {
            return dbcontext.ProductsMains.Include(x => x.OrderDetails).Include(x=>x.IdSnifNavigation).ToList();
        }

        public async Task<List<ProductsMain>> GetAsync()
        {
            return await dbcontext.ProductsMains.Include(x => x.OrderDetails).Include(x => x.IdSnifNavigation).ToListAsync();

        }

        public async Task<ProductsMain> GetByIdAsync(int id)
        {
            var l = await GetAsync();
            return l.Find(x => x.Id == id);
        }

        public List<ProductsMain> GetByIdProduct(int id)
        {
            return Get().Where(x=>x.IdProduct==id ).ToList();
        }

        public void notUse(int p)
        {
            ProductsMain? f = Get().Find(pm => pm.Id == p);
            if (f != null)
            {
                f.CanBeUsed = false;
            }
            dbcontext.SaveChanges();
        }

        public void Update(int p)
        {
            ProductsMain? f= Get().Find(pm=>pm.Id == p);
            if (f != null)
            {
                if (f.Available == false)
                {
                    f.Available = true;
                    f.DayTaken = null;
                }
                else
                {
                    f.Available = false;
                    f.Price -= 3;
                    f.DayTaken = DateTime.Now.AddDays(10);
                }
            }
            dbcontext.SaveChanges();
        }



    }
}
