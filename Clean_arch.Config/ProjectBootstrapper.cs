using Clean_arch.Application.Orders;
using Clean_arch.Application.Orders.Services;
using Clean_arch.Application.Products;
using Clean_arch.Domain.OrderAgg.Services;
using Clean_arch.Domain.Orders.Repository;
using Clean_arch.Domain.Products.Repository;
using Clean_arch.Infrastructure.Persistent.Memory;
using Clean_arch.Infrastructure.Persistent.Memory.Order;
using Clean_arch.Infrastructure.Persistent.Memory.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Clean_arch.Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IOrderService,OrderService>();
            services.AddTransient<IProductService,ProductService>();
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IOrderDomainService,OrderDomainService>();


            services.AddSingleton<Context>();
        }
    }
}
