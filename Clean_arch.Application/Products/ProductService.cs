using Clean_arch.Application.Products.Dtos;
using Clean_arch.Domain.Products;
using Clean_arch.Domain.Products.Repository;
using Clean_arch.Domain.Shared;

namespace Clean_arch.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(AddProductDto command)
        {
            _repository.Add(new Product(command.Title, Money.FromTooman(command.Price)));
            _repository.Save();
        }

        public void EditProduct(EditProductDto command)
        {
            var product = _repository.GetById(command.Id);
            product.Edit(command.Title, Money.FromTooman(command.Price));
            _repository.Update(product);
            _repository.Save();
        }

        public ProductDto GetProductById(Guid id)
        {
            var product = _repository.GetById(id);
            return new ProductDto()
            {
                Id = id,
                Title = product.Title,
                Price = product.Price.Value,
            };
        }

        public List<ProductDto> GetProducts()
        {
            return _repository.GetList().Select(product => new ProductDto()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price.Value,
            }).ToList();
        }
    }
}
