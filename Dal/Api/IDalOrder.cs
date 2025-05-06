
using Dal.Models;

namespace Dal.Api
{
    public interface IDalOrder
    {
        List<Order> GetAll();
        List<Order> GetByIdCustomer(string id);
       void Create(Order c);

    }
}
