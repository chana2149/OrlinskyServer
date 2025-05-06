using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalCustomers
    {
        Task CreateAsync(Costumer c);
        Task<List<Costumer>> GetAsync();
        Task<Costumer> GetByIdAsync(string id);
        Task CreateFavoriteAsync(string customerId, int productId);
        Task DeleteFavoriteAsync(string customerId, int productId);
    }
}