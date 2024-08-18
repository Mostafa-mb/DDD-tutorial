using Clean_arch.Domain.OrderAgg;
using Clean_arch.Domain.OrderAgg.Events;
using Clean_arch.Domain.OrderAgg.Exceptions;
using Clean_arch.Domain.OrderAgg.Services;
using Clean_arch.Domain.Products;
using Clean_arch.Domain.Shared;
using Clean_arch.Domain.Shared.Exceptions;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Clean_arch.Domain.Orders
{
    public class Order : AggregateRoot
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public int TotalItems { get; set; }
        public ICollection<OrderItem> Items { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public int TotalPrice;

        public Order(long userId)
        {
            UserId = userId;
            Items = new List<OrderItem>();
        }
        

        public void IncreaseProductCount(int count)
        {

        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            AddDomainEvent(new OrderFinalized(Id, UserId));
        }

        public void AddItem(long productId, int count, int price , IOrderDomainService orderService)
        {
            if(orderService.IsProductNotExist(productId))
            {
                throw new ProductNotFoundException();
            }
            if(Items.Any(p => p.ProductId == productId))
            {
                return;
            }
            Items.Add(new OrderItem(Id, productId, count, Money.FromTooman(price)));
            TotalItems += count;
        }

        public void RemoveItem(long productId)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);
            if (item == null)
            {
                throw new InvalidDomainDataException("آیتم وجود ندارد.");
            }
            Items.Remove(item);
            TotalItems -= item.Count;
        }



    }
}
