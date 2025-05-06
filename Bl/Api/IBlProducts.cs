using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlProducts
    {
        List<BlProduct> Get();
        List<BlProduct> GetByCattegory(int cat);
        void Create(BlProduct p);
        BlProduct GetById(int id);
        void Update(BlProduct p);
    }
}
