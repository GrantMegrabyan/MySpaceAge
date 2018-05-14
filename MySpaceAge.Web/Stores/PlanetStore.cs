using System.Threading;
using System.Threading.Tasks;
using MySpaceAge.Web.Models;
using NodaTime;

namespace MySpaceAge.Web.Stores
{
    public class PlanetStore
    {
        public Task<Planet[]> GetPlanets(CancellationToken cancelationToken)
        {
            var mercury = new Planet
            {
                Name = "Mercury",
                YearDuration = Duration.FromDays(87.969),
                DayDuration = Duration.FromHours(1408)
            };

            var venus = new Planet
            {
                Name = "Venus",
                YearDuration = Duration.FromDays(224.7),
                DayDuration = Duration.FromHours(5832)
            };

            var earth = new Planet
            {
                Name = "Earth",
                YearDuration = Duration.FromDays(365.25),
                DayDuration = Duration.FromHours(24)
            };

            var mars = new Planet
            {
                Name = "Mars",
                YearDuration = Duration.FromDays(687),
                DayDuration = Duration.FromHours(25)
            };

            return Task.FromResult(new[]{mercury, venus, earth, mars});
        }
    }
}