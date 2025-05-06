using Dal.Api;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Api;
using BL.Services;
using Bl.Api;
using BL.Models;
using Dal.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Bl
{
    public class BlManager:Ibl
    {
       
        public IBlSniffim Sniffim { get; }
        public IBlCustomers Customers { get; }
        public IBlOrders Orders { get; }

        public IBlProducts Products { get; }

        public IBlCattegory Cattegory { get; }
        public IBlProductsMain ProductsMain { get; }

        public BlManager()
        {
           

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBlCattegory, BlCattegoryService>();
            services.AddSingleton<IBlCustomers, BlCustomersService>();
            services.AddSingleton<IBlOrders, BlOrderService>();
            services.AddSingleton<IBlProducts, BlProductsService>();
            services.AddSingleton<IBlProductsMain,BlProductsMainService >();
            services.AddSingleton<IBlSniffim, BlSniffimService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

         
            Products = serviceProvider.GetRequiredService<IBlProducts>();
            Sniffim = serviceProvider.GetRequiredService<IBlSniffim>();
            Customers = serviceProvider.GetRequiredService<IBlCustomers>();
            Orders = serviceProvider.GetRequiredService<IBlOrders>();
            ProductsMain = serviceProvider.GetRequiredService<IBlProductsMain>();
            Cattegory = serviceProvider.GetRequiredService<IBlCattegory>();
        }
        
    }
}
