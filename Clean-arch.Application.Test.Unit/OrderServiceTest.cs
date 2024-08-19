using Clean_arch.Application.Orders;
using Clean_arch.Application.Orders.DTOs;
using Clean_arch.Domain.Orders;
using Clean_arch.Domain.Orders.Repository;
using NSubstitute;

namespace Clean_arch.Application.Test.Unit
{
    public class OrderServiceTest
    {
        private readonly OrderService _orderService;
        private readonly IOrderRepository _repositories;

        public OrderServiceTest()
        {
            _repositories = Substitute.For<IOrderRepository>();
            _orderService = new(_repositories);
        }

        [Fact]
        public void Should_Add_Order()
        {
            //arrange
            var command = new AddOrderDto(1, 3, 2000);

            //act
            _orderService.AddOrder(command);

            //assert
            _repositories.Received(1).SaveChanges();
        }

        [Fact]
        public void FinallyOrder_Should_Finally_Order()
        {
            //arrange
            _repositories.GetById(Arg.Any<long>()).Returns(new Order(1));
            var command = new FinallyOrderDto(2);

            //act
            _orderService.FinallyOrder(command);

            //assert
            _repositories.Received(1).SaveChanges();
        }

        //[Fact]
        //public void Should_Return_Order_By_Id()
        //{
        //    //arrange
        //    _repositories.GetById(Arg.Any<long>()).Returns(new Order(2));

        //    //act
        //    var result = _orderService.GetOrderById(1);

        //    //assert
        //    result.UserId.Should().Be(2);
        //}


    }
}