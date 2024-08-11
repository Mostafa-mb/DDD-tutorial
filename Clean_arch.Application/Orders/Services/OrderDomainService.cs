using Clean_arch.Domain.OrderAgg.Services;
using Clean_arch.Domain.Products.Repository;

namespace Clean_arch.Application.Orders.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IProductRepository _productRepository;

        public OrderDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsProductNotExist(long productId)
        {
            var productIsExist = _productRepository.IsProductExist(productId); ;
            return !productIsExist;
        }
    }
}
