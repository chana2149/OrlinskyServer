using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalProductsMain
    {
        List<ProductsMain> Get( );
        Task<List<ProductsMain>> GetAsync();
        Task<ProductsMain> GetByIdAsync(int id);
        List<ProductsMain> GetByIdProduct(int id);
        // void Create(ProductsMain p);


        Task CreateAsync(ProductsMain pm);

        void Update(int p);
        void notUse(int p);

    }
}
