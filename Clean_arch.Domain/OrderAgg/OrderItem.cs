using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(long orderId, long productId, int count, Money price)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
            Price = price;
        }

        public long Id { get; private set; }
        public long OrderId { get; protected set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public Money Price { get; private set; }
    }
}
