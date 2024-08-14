namespace Calculator.Unit.Test.ClassFixture
{
    public class ComputingClassFixture : IDisposable
    {

        public Computing Computing;

        public ComputingClassFixture()
        {
            Computing = new();
        }

        public void Dispose()
        {
            //
        }
    }
}
