using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.Models;
using System.Threading.Tasks;
using Dal.Api;
using Dal.Services;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalCostumerService : IDalCustomers
    {
        IDalProductsMain p1;
        dbcontext dbcontext;

        public DalCostumerService(dbcontext data, IDalProductsMain p1)
        {
            dbcontext = data;
            this.p1 = p1;
        }

        public async Task CreateAsync(Costumer c)
        {
            await dbcontext.Costumers.AddAsync(c);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<List<Costumer>> GetAsync()
        {
            return await dbcontext.Costumers
                .Include(x => x.IdFavorates)
                    .ThenInclude(x => x.IdProductNavigation)
                .Include(x => x.IdFavorates)
                    .ThenInclude(x => x.IdSnifNavigation)
                .ToListAsync();
        }

     

        public async Task<Costumer> GetByIdAsync(string id)
        {
            // יעיל יותר לבצע שאילתה ישירה במקום להביא את כל הלקוחות
            return await dbcontext.Costumers
                .Include(x => x.IdFavorates)
                    .ThenInclude(x => x.IdProductNavigation)
                .Include(x => x.IdFavorates)
                    .ThenInclude(x => x.IdSnifNavigation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteFavoriteAsync(string customerId, int productId)
        {
            var customer = await GetByIdAsync(customerId);
            
            if (customer != null)
            {
                var productToRemove = customer.IdFavorates.ToList().Find(x => x.Id == productId);
                
                if (productToRemove != null)
                {
                    customer.IdFavorates.Remove(productToRemove);
                    await dbcontext.SaveChangesAsync();
                }
            }
        }
        public async Task CreateFavoriteAsync(string customerId, int productId)
        {
            var customer = await GetByIdAsync(customerId);
            var l = await p1.GetByIdAsync(productId);
          /*  var productMain = l.(y => y.Id == productId);*/
          

            if (customer != null && l != null)
            {
                customer.IdFavorates.Add(l);
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}