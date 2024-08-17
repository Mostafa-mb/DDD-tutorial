using Clean_arch.Domain.ProductAgg;
using Clean_arch.Domain.Shared.Exceptions;
using Clean_arch.Domain.Test.Unit.Builder;
using FluentAssertions;

namespace Clean_arch.Domain.Test.Unit.ProductAgg
{
    public class ProductImageTests
    {

        [Fact]
        public void Constructor_Should_Create_ProductImage_When_Data_Is_Given()
        {
            //arrange
            var productImage = new ProductImages(2, "test1.png");

            //assert

            productImage.ImageName.Should().Be("test1.png");
        }
        
        
        [Fact]
        public void Constructor_Should_Throw_Exception_when_ImageName_Is_NullOrEmpty()
        {
            //arrange
            var result = () => new ProductImages(2, "");


            //assert

            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("ImageName is null or empty");
        }
    }
}
