using Clean_arch.Application.Products.Dtos;

namespace Clean_arch.Application.Products
{
    public interface IProductService
    {
        void AddProduct(AddProductDto command);
        void EditProduct (EditProductDto command);
        ProductDto GetProductById(long id);
        List<ProductDto> GetProducts();
    }
}
