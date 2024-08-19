using Clean_arch.Application.Orders.DTOs;
using Clean_arch.Domain.Orders;
using Clean_arch.Domain.Orders.Repository;
using System.Collections.Generic;

namespace Clean_arch.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void AddOrder(AddOrderDto command)
        {
            var order = new Order(command.ProductId);
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
        }

        public void FinallyOrder(FinallyOrderDto command)
        {
            var order = _orderRepository.GetById(command.OrderId);
            order.Finally();
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
        }

        public OrderDto GetOrderById(long id)
        {
            var order = _orderRepository.GetById(id);
            return new OrderDto()
            {
                Id = order.Id,
                UserId = order.UserId,
            };
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.GetList().Select(order => new OrderDto()
            {
                Id = order.Id,
                ProductId = order.ProductId,
            }).ToList();
        }
    }

    public interface IOrderService
    {
        void AddOrder(AddOrderDto command);
        void FinallyOrder(FinallyOrderDto command);
        OrderDto GetOrderById(long id);
        List<OrderDto> GetOrders();

    }
}
