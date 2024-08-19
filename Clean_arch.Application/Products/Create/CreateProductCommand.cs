using MediatR;

namespace Clean_arch.Application.Products.Create
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(string title, int price)
        {
            Title = title;
            Price = price;
        }

        public string Title { get; set; }
        public int Price { get; set; }
    }
}
