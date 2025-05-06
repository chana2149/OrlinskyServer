using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlProductsMain
    {
        List<BlProductsMain> Get();

        List<BlProductsMain> GetByIdProduct(int id);
        void notUse(int p);

        void Update(int p);
        //void Create(BlProductsMain p);


        Task CreateAsync(BlProductsMain pm);

        public BlProduct prodtoBlProd1(Product p);

    }
}
