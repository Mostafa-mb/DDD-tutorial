using FluentAssertions;
using System.Dynamic;

namespace Calculator.Unit.Test
{
    public class ComputingTests
    {

        Computing Computing;
        public ComputingTests()
        {
            Computing = new();
        }

        [Fact]
        public void OddOrEven_Should_Return_Odd_When_Input_Is_OddValue()
        {
            var result = Computing.OddOrEven(11);
            //Assert.Equal("Odd", result);
            result.Should().Be("Odd");

        }


        [Theory]
        [InlineData(10)]
        public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue2(int value)
        {
            var result = Computing.OddOrEven(10);
            result.Should().Be("Even");
        }

        [Fact] 
        public void CalculateAge_Should_Return_Zero_When_Birth_LessThan_Zero()
        {
            var result = Computing.CalculateAge(-1, 1400);
            result.Should().Be(0);
        }
        
        [Fact] 
        public void CalculateAge_Should_Throw_ArgumentException_When_Birth_Or_currentYear_Zero()
        {
            var result = new Action(() =>
            {
                Computing.CalculateAge(0, 1400);
            });
            
            result.Should().Throw<ArgumentException>();
        }
        
        [Fact] 
        public void CalculateAge_Should_Calculate_Age()
        {
            var result = Computing.CalculateAge(1350, 1400);
            result.Should().Be(50);
        }


        [Fact]
        public void IsPrime_false_with_value_lessThan_2()
        {
            var result = Computing.IsPrime(1);
            result.Should().Be(false);
        }

        [Fact]
        public void IsPrime_false_When_DevideResult_EqualTo_0()
        {
            var result = Computing.IsPrime(6);
            result.Should().Be(false);
        }
        
        
        [Fact]
        public void IsPrime_True_When_DevideResult_Not_EqualTo_0()
        {
            var result = Computing.IsPrime(5);
            result.Should().Be(true);
        }

    }
}
