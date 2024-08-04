using Clean_arch.Domain.Orders;

namespace Clean_arch.Infrastructure.Persistent.Memory
{
    public  class Context
    {
        public  List<Domain.Products.Product> Products { get; set; }
        public  List<Domain.Orders.Order> Orders { get; set; } = new List<Domain.Orders.Order>() { new Domain.Orders.Order(Guid.NewGuid(),5,1000) };
    }
}
