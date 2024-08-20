using Clean_arch.Domain.Orders;

namespace Clean_arch.Domain.Products.Repository
{
    public interface IProductRepository
    {
        List<Product> GetList();
        Task<Product> GetById(long id);
        void Add(Product product);
        void Update(Product product);
        Task Save();
        void Remove(Product product);
        bool IsProductExist(long id);
    }
}
