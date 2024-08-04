using Clean_arch.Domain.Products.Repository;

namespace Clean_arch.Infrastructure.Persistent.Memory.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public void Add(Domain.Products.Product product)
        {
            _context.Products.Add(product);
        }

        public Domain.Products.Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Domain.Products.Product> GetList()
        {
            return _context.Products;
        }

        public void Remove(Domain.Products.Product product)
        {
            _context.Products.Remove(product);
        }

        public void Save()
        {
            ///
        }

        public void Update(Domain.Products.Product product)
        {
            var currentProduct = GetById(product.Id);
            _context.Products.Remove(currentProduct);
            _context.Products.Add(product);
        }
    }
}
