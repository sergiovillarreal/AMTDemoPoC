using AmtDirectCalculator.SharedKernel.Interfaces.Models;

namespace AmtDirect.Core.Models
{
    public class CalendarPeriod : ICalendarPeriod
    {
        public CalendarPeriod()
        {
        }

        public string Period { get; set; }
    }
}