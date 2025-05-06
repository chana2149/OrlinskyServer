using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager:IDal
    {
        public IDalSniffim Sniffim { get; }
        public IDalCustomers Costomers { get; }

        public IDalProducts Products { get; }

        public IDalCattegory Cattegory { get; }

        public IDalOrder Order { get; }

        public IDalProductsMain ProductsMain { get; }

        public IDalOrderDetail OrderDetail { get; }

        public DalManager()
        {

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<dbcontext>();

            services.AddSingleton<IDalCattegory, DalCattegoryService>();
            services.AddSingleton<IDalCustomers, DalCostumerService>();
            services.AddSingleton<IDalOrder, DalOrderService >();
            services.AddSingleton<IDalProducts, DalProductService>();
            services.AddSingleton<IDalProductsMain, DalProductMainService>();
            services.AddSingleton<IDalSniffim, DalSniffimService>();
            services.AddSingleton<IDalOrderDetail, DalOrderDetailService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Products = serviceProvider.GetRequiredService<IDalProducts>();
            Sniffim = serviceProvider.GetRequiredService<IDalSniffim>();
            Costomers = serviceProvider.GetRequiredService<IDalCustomers>();
            Order = serviceProvider.GetRequiredService<IDalOrder>();
            ProductsMain = serviceProvider.GetRequiredService<IDalProductsMain>();
            Cattegory = serviceProvider.GetRequiredService<IDalCattegory>();
        }
    }
}
