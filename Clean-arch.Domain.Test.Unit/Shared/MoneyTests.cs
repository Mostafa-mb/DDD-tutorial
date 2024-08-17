using Clean_arch.Domain.Shared;
using Clean_arch.Domain.Shared.Exceptions;
using FluentAssertions;

namespace Clean_arch.Domain.Test.Unit.Shared
{
    public class MoneyTests
    {

        [Fact]
        public void Constructor_Should_Set_Value_When_Value_Bigger_Than_Zero()
        {
            var money = new Money(1000);

            money.Value.Should().Be(1000);
        }

        [Fact]
        public void Constructor_Must_Throw_InvalidDomainDataException_with_InValid_Data()
        {

            var money = () => new Money(-10);


            money.Should().ThrowExactly<InvalidDomainDataException>();
        }

        [Fact]
        public void FromRial_Should_Create_Money()
        {

            var money = Money.FromRial(1000);


            money.Value.Should().Be(1000);
        }

        [Fact]
        public void FromTooman_Should_Create_Money()
        {
            var toomanValue = 1000;
            var money = Money.FromTooman(toomanValue);


            money.Value.Should().Be(toomanValue*10);
        }

        [Fact]
        public void PlusOperator_Should_Plus_Two_Money_Values()
        {
            //arrange
            var value1 = new Money(1000);
            var value2 = new Money(2000);

            //act

            var result = value1 + value2;

            //assert

            result.Value.Should().Be(3000);
        }

        [Fact]
        public void ToString_Should_Add_Specific_Price_Format()
        {
            //arrange
            var money = Money.FromRial(10000);


            //act

            var result = money.ToString();

            //assert

            result.Should().Be("10,000");
        }

        [Fact]
        public void MinusOperator_Should_Minus_Two_Money_Values()
        {
            //arrange
            var value1 = new Money(3000);
            var value2 = new Money(2000);

            //act

            var result = value1 - value2;

            //assert

            result.Value.Should().Be(1000);
        }
    }
}
