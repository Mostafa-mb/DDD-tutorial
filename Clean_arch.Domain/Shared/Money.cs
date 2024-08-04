namespace Clean_arch.Domain.Shared
{
    public class Money
    {

        /// <summary>
        /// Rial
        /// </summary>
        public int Value { get;}

        public Money(int rialValue)
        {
            if (rialValue < 0)
            {
                throw new InvalidDataException();
            }
            Value = rialValue;
        }
    }
}
