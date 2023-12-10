namespace Common.Constants
{
    public static class StatusMessageConstants
    {
        private const string Ok = "Your piping hot coffee is ready";

        private const string Exception = "Exception";

        public static string Get(int number)
        { 
            switch (number)
            {
                case 200: return Ok;
                default: return Exception;
            }
        }
    }
}
