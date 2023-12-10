using Common.Interfaces;

namespace Common
{
    public static class CustomDateTimeFormat
    {
        //ISO-8601
        public static string GetDateTimeFormattedIso(this IDateTimeSnapshot dateTimeSnapshot) {
            return dateTimeSnapshot.GetDate.ToString("yyyy-MM-ddTHH:mm:sszz");
        }
    }
}
