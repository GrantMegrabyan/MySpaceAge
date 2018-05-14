using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySpaceAge.Web.Models;
using MySpaceAge.Web.Stores;
using NodaTime;

namespace MySpaceAge.Web.Controllers
{
    [Route("api/[controller]")]
    public class PlanetController : Controller
    {
        private readonly PlanetStore _planetStore;

        public PlanetController(PlanetStore planetStore)
        {
            this._planetStore = planetStore;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var planets = await _planetStore.GetPlanets(cancellationToken);
            return Ok(planets);
        }
    }
}