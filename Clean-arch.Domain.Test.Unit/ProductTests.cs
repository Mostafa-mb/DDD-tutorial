using Clean_arch.Domain.Products;
using Clean_arch.Domain.Shared.Exceptions;
using Clean_arch.Domain.Test.Unit.Builder;
using FluentAssertions;

namespace Clean_arch.Domain.Test.Unit
{
    public class ProductTests
    {

        private ProductBuilder _builder;
        public ProductTests()
        {
            _builder = new ProductBuilder();
        }


        [Fact]
        public void Constructor_Should_Create_Product_When_Data_IsOkay()
        {

            //arrange
            _builder.SetTitle("test2").SetMoney(2000000).Build();

            //act

            var product = _builder.Build();

            //assert
            product.Title.Should().Be("test2");
        }

        [Fact]
        public void Cunstructor_Should_Throw_NullOrEmptyException_When_title_IsNull()
        {

            //act
            var action = new Action(() =>
            {
                _builder.SetTitle("").Build();
            });

            //assert
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");
        }
    }
}