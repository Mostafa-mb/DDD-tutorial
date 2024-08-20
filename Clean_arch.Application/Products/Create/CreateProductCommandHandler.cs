using Clean_arch.Domain.Products;
using Clean_arch.Domain.Products.Repository;
using MediatR;
using Clean_arch.Domain.Shared;

namespace Clean_arch.Application.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {

        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Title , Money.FromTooman(request.Price));
            _repository.Add(product);
            _repository.Save();

            return Unit.Task;
        }
    }
}
