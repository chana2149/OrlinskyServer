using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlCustomersService : IBlCustomers
    {
        IDal dal;
        IBlProductsMain p1;

        public BlCustomersService(IDal dal, IBlProductsMain p1)
        {
            this.dal = dal;
            this.p1 = p1;
        }

        public async Task CreateAsync(BlCostumer costumer)
        {
            Costumer c = new Costumer()
            {
                Id = costumer.Id,
                Name = costumer.Name,
                Address = costumer.Address,
                Telephone = costumer.Telephone
            };
            await dal.Costomers.CreateAsync(c);
        }

        public async Task<List<BlCostumer>> GetAsync()
        {
            var pList = await dal.Costomers.GetAsync();
            List<BlCostumer> list = new();

            foreach (var p in pList)
            {
                list.Add(new BlCostumer()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    Telephone = p.Telephone,
                    IdFavorates = await ((BlProductsMainService)p1).prodtoBlProdAsync(p.IdFavorates.ToList())
                });
            }

            return list;
        }

        public async Task<BlCostumer> GetByIdAsync(string id)
        {
            var customer = await dal.Costomers.GetByIdAsync(id);
            return await custToBlcustAsync(customer);
        }

        public async Task<BlCostumer> custToBlcustAsync(Costumer c)
        {
            if (c == null)
                return null;

            BlCostumer c2 = new()
            {
                Id = c.Id,
                Telephone = c.Telephone,
                Address = c.Address,
                Name = c.Name,
                IdFavorates = await ((BlProductsMainService)p1).prodtoBlProdAsync(c.IdFavorates.ToList())
            };

            return c2;
        }

        public async Task CreateFavoriteAsync(string customerId, int productId)
        {
            await dal.Costomers.CreateFavoriteAsync(customerId, productId);
        }

        public async Task DeleteFavoriteAsync(string customerId, int productId)
        {
            await dal.Costomers.DeleteFavoriteAsync(customerId, productId);
        }
    }
}
