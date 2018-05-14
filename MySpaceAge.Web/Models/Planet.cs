using NodaTime;

namespace MySpaceAge.Web.Models
{
    public class Planet
    {
        public string Name {get;set;}
        public Duration YearDuration { get; set; }
        public Duration DayDuration { get; set; }
    }
}