
namespace Common.Exceptions
{
    public class AprilFoolException: Exception
    {
        public AprilFoolException() : base() { }
        public AprilFoolException(string message) : base(message) { }
        public AprilFoolException(string message, Exception innerException) : base(message, innerException) { }
    }
}
