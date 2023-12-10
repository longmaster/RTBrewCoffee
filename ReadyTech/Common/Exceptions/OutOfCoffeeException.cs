
namespace Common.Exceptions
{
    public class OutOfCoffeeException: Exception
    {
        public OutOfCoffeeException() : base() { }
        public OutOfCoffeeException(string message) : base(message) { }
        public OutOfCoffeeException (string message, Exception innerException) : base(message, innerException) { }
    }
}
