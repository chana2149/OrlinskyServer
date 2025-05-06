using BL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface Ibl { 
        public IBlProducts Products { get; }
        public IBlProductsMain ProductsMain { get; }
        public IBlOrders Orders { get; }
        public IBlCattegory Cattegory { get; }
        public IBlSniffim Sniffim { get; }
        public IBlCustomers Customers { get; }
    }

}
