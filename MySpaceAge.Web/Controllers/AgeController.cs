using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MySpaceAge.Web.Services;
using MySpaceAge.Web.Stores;
using NodaTime;

namespace MySpaceAge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeController : Controller
    {
        private readonly PlanetStore _planetStore;
        private readonly AgeService _ageService;
        private readonly IClock _clock;

        public AgeController(
            PlanetStore planetStore, 
            AgeService ageService,
            IClock clock)
        {
            this._planetStore = planetStore;
            this._ageService = ageService;
            this._clock = clock;
        }

        // [HttpGet("{planetName}/{earthYears}")]
        // public async Task<IActionResult> Get(string planetName, int earthYears, CancellationToken cancellationToken)
        // {
        //     var planets = await _planetStore.GetPlanets(cancellationToken);
        //     var planet = planets.FirstOrDefault(p => p.Name.Equals(planetName, StringComparison.OrdinalIgnoreCase));

        //     if (planet == null)
        //     {
        //         return BadRequest($"Planet '{planetName}' not found");
        //     }

        //     var ageOnPlanet = _ageService.CalculateAge(planet, Duration.FromDays(365.25 * earthYears));

        //     return Ok(ageOnPlanet);
        // }

        public class GetAgeCommand
        {
            [Required]
            public string planetName {get;set;}

            [BindRequired]
            public DateTime birthday {get;set;}
        }

        [HttpGet]
        public async Task<ActionResult<Period>> Get(
            // [Required] string planetName ,
            // [Required] DateTime birthday 
            [FromQuery]GetAgeCommand command
            )
        {
            string planetName = command.planetName;
            var birthday = command.birthday;
            birthday = DateTime.SpecifyKind(birthday, DateTimeKind.Utc);
            // DateTime birthday1 = new DateTime(1986, 4, 19, 0, 0, 0, DateTimeKind.Utc);

            var planets = await _planetStore.GetPlanets(CancellationToken.None);
            var planet = planets.FirstOrDefault(p => p.Name.Equals(planetName, StringComparison.OrdinalIgnoreCase));

            if (planet == null)
            {
                return BadRequest($"Planet '{planetName}' not found");
            }

            Instant now = _clock.GetCurrentInstant();
            Instant bd = Instant.FromDateTimeUtc(birthday);

            Duration age = now - bd;

            var ageOnPlanet = _ageService.CalculateAge(planet, age);

            return ageOnPlanet;
        }
    }

}