using Clean_arch.Domain.Orders;
using Clean_arch.Domain.Orders.Repository;

namespace Clean_arch.Infrastructure.Persistent.Memory.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        public OrderRepository(Context context)
        {
            _context = context;
        }
        public void Add(Domain.Orders.Order order)
        {
            _context.Orders.Add(order);
        }

        public Domain.Orders.Order GetById(long id)
        {
            return _context.Orders.SingleOrDefault(p => p.Id == id);
        }

        public List<Domain.Orders.Order> GetList()
        {
            return _context.Orders;
        }

        public void SaveChanges()
        {
            //
        }

        public void Update(Domain.Orders.Order order)
        {
            var CurrentOrder = GetById(order.Id);
            _context.Orders.Remove(CurrentOrder);
            _context.Orders.Add(order);
        }
    }
}
