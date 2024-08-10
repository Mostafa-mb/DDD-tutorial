namespace Clean_arch.Application.shared
{
    public class BaseCommandException : Exception
    {
        public BaseCommandException()
        {
            
        }

        public BaseCommandException(string message) : base(message) 
        {
            
        }
    }
}
