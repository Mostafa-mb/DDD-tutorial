namespace Calculator.Unit.Test
{
    public class ComputingTests
    {
        [Fact]
        public void OddOrEven_Should_Return_Odd_When_Input_Is_OddValue()
        {
            var computing = new Computing();
            var result = computing.OddOrEven(11);
            Assert.Equal("Odd", result);
        }

        //[Fact]
        //public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue()
        //{
        //    var computing = new Computing();
        //    var result = computing.OddOrEven(10);
        //    Assert.Equal("Even", result);
        //}

        [Theory]
        [InlineData(10)]
        public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue2(int value)
        {
            var computing = new Computing();
            var result = computing.OddOrEven(10);
            Assert.Equal("Even", result);
        }
    }
}
