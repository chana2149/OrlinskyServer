using BL.Models;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlSniffim
    {
        List<BlSniffim> Get();
        void Update(BlSniffim p);
        void Create(BlSniffim  p);
    }
}
