
using BL.Models;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlCustomers
    {
        Task CreateAsync(BlCostumer costumer);
        Task<List<BlCostumer>> GetAsync();
        Task<BlCostumer> GetByIdAsync(string id);
        Task CreateFavoriteAsync(string customerId, int productId);
        Task DeleteFavoriteAsync(string customerId, int productId);
    }
}
