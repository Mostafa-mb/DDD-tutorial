using Clean_arch.Domain.Products;
using Clean_arch.Domain.Shared.Exceptions;
using Clean_arch.Domain.Test.Unit.Builder;
using FluentAssertions;
using Clean_arch.Domain.Shared;
using System;

namespace Clean_arch.Domain.Test.Unit.ProductAgg
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
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>()
                .WithMessage("title is null or empty");
        }

        [Fact]
        public void Edit_Should_Update_Product_When_Data_IsOkay()
        {

            //arrange

            var product = _builder.SetTitle("test2").SetMoney(2000000).Build();

            //act

            product.Edit("edited", new Money(20000));

            //assert
            product.Title.Should().Be("edited");
            product.Price.Value.Should().Be(20000);
        }

        [Fact]
        public void Edit_Should_Throw_NullOrEmptyException_When_title_IsNull()
        {

            //arrange

            var product = _builder.SetTitle("test2").SetMoney(2000000).Build();

            //act

            var action = () =>
            {
                product.Edit("", new Money(20000));
            };

            //assert
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>()
                .WithMessage("title is null or empty");

        }


        [Fact]
        public void AddImage_Should_Add_New_Image_To_Product()
        {

            //arrange

            var product = _builder.SetTitle("test2").SetMoney(2000000).Build();

            //act

            product.AddImages("test.png");

            //assert

            product.Images.Should().HaveCount(1);
        }


        [Fact]
        public void RemoveImage_Should_Remove_Image_When_Image_Is_Exist()
        {

            //arrange

            var product = _builder.SetTitle("test2").SetMoney(2000000).Build();
            product.AddImages("test.png");

            //act

            product.RemoveImages(0);

            //assert

            product.Images.Should().HaveCount(0);
        }

        [Fact]
        public void RemoveImage_Should_Throw_NullOrEmptyException_When_Image_Is_Not_Exist()
        {

            //arrange

            var product = _builder.SetTitle("test2").SetMoney(2000000).Build();

            //act

            var action = () =>
            {
                product.RemoveImages(10);
            };


            //assert

            action.Should().Throw<NullOrEmptyDomainDataException>().WithMessage("image not found!!");
        }
    }
}