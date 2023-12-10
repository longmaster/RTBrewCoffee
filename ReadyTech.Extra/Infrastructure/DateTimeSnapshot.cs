using Common.Interfaces;

namespace Infrastructure
{
    public class DateTimeSnapshot : IDateTimeSnapshot
    {
        public DateTime GetDate { get; }

        public DateTimeSnapshot()
        {
            GetDate = DateTime.Now;
            //GetDate = new DateTime(2023,04,01);
        }

    }
}
