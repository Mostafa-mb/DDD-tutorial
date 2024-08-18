using Clean_arch.Domain.OrderAgg.Events;
using Clean_arch.Domain.OrderAgg.Exceptions;
using Clean_arch.Domain.OrderAgg.Services;
using Clean_arch.Domain.Orders;
using Clean_arch.Domain.Shared.Exceptions;
using FluentAssertions;
using NSubstitute;

namespace Clean_arch.Domain.Test.Unit.OrderAgg
{
    public class OrderTests
    {
        [Fact]
        public void Should_Create_Order()
        {
            var order = new Order(1);

            order.UserId.Should().Be(1);
            order.IsFinally.Should().Be(false);
        }

        [Fact]
        public void Should_Finally_Order_And_Add_DomainEvent()
        {
            //arrange
            var order = new Order(1);

            //act
            order.Finally();

            //assert
            order.DomainEvents.Should().ContainEquivalentOf(new OrderFinalized(0,1));
        }
        
        [Fact]
        public void AddItem_Should_Throw_ProductNotFoundException_When_Product_Not_Exist()
        {
            //arrange
            var order = new Order(1);
            var OrderDomainService = Substitute.For<IOrderDomainService>();
            OrderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(true);
            //act
            var action = () => order.AddItem(1,2,2000,OrderDomainService);

            //assert
            action.Should().ThrowExactly<ProductNotFoundException>().WithMessage("product does not found");
        }

        [Fact]
        public void AddItem_Should_Add_New_Item_To_Order()
        {
            //arrange
            var order = new Order(1);
            var OrderDomainService = Substitute.For<IOrderDomainService>();
            OrderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);
            //act
            order.AddItem(1, 2, 2000, OrderDomainService);

            //assert
            order.TotalItems.Should().Be(2);
        }

        [Fact]
        public void Should_Not_Add_New_Item_To_Order_When_Product_Exist()
        {
            //arrange
            var order = new Order(1);
            var OrderDomainService = Substitute.For<IOrderDomainService>();
            OrderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 2000, OrderDomainService);

            //act
            order.AddItem(1, 3, 2000, OrderDomainService);

            //assert
            order.TotalItems.Should().Be(2);
        }

        [Fact]
        public void RemoveItme_Should_Throw_InvalidDataException_When_Product_Not_Exist_In_Order()
        {
            //arrange
            var order = new Order(1);
            var OrderDomainService = Substitute.For<IOrderDomainService>(); 
            OrderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 2000, OrderDomainService);

            //act
            var action = () => order.RemoveItem(2);

            //assert
            action.Should().ThrowExactly<InvalidDomainDataException>().WithMessage("آیتم وجود ندارد.");
        }

        [Fact]
        public void RemoveItme_Should_Remove_Product_When_Product_Exist_In_Order()
        {
            //arrange
            var order = new Order(1);
            var OrderDomainService = Substitute.For<IOrderDomainService>();
            OrderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 2000, OrderDomainService);

            //act
            order.RemoveItem(1);

            //assert
            order.TotalItems.Should().Be(0);
        }
    }
}
 