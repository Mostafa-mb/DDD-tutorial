using Clean_arch.Domain.Products;
using MediatR;

namespace Clean_arch.Application.Products.Edit
{
    public class EditProductCommand : IRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
