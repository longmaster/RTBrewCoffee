namespace Common.Constants;

public static class StatusMessageConstants
{

    private const string Ok = "Your piping hot coffee is ready";
    private const string TempGreaterThanThirty = "Your refreshing iced coffee is ready";

    private const string Exception = "Exception";

    public static string Get(int statusCode)
    { 
        switch (statusCode)
        {
            case 200: return Ok;
            default: return Exception;
        }
    }
    public static string GetByTemperature(double temperature)
    {
        switch (temperature)
        {
            case > 30: return TempGreaterThanThirty;
            default: return string.Empty;
        }
    }
}
