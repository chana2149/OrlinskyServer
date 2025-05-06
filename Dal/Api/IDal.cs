using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal {
       public IDalProducts Products { get; }
        public IDalProductsMain ProductsMain { get; }
        public IDalCattegory Cattegory { get; }
        public IDalSniffim Sniffim{get; }
        public IDalCustomers Costomers { get; }
        public IDalOrder Order { get; }
        public IDalOrderDetail OrderDetail { get; }

    }
}
