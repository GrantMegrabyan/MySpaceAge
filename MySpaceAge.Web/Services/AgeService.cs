using System;
using MySpaceAge.Web.Models;
using NodaTime;

namespace MySpaceAge.Web.Services
{
    public class AgeService
    {
        public Period CalculateAge(Planet planet, Duration earthAge)
        {
            var years = earthAge.TotalSeconds / planet.YearDuration.TotalSeconds;

            var pb = new PeriodBuilder();
            pb.Years = (int)Math.Round(years); 
            pb.Days = 40;
            return pb.Build();
        }

        // public Period CalculateAge(Planet planet, Instant birthday)
        // {

        //     planet.YearDuration.TotalSeconds
        //     //planet.
        //     //return PeriodBuilder
        //     .
        // }
    }
}