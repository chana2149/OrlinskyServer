using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalProducts
    {
        void Create(Product c);
        List<Product> Get();
        List<Product> GetByCattegory(int cattegory);
        Product GetById(int id);

        void Update(Product p);
    }
}
