using AutoMapper;
using CityInfo.Api.Models;
using CityInfo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _citiesDataRepository;
        private readonly IMapper _map;
        public CitiesController(ICityInfoRepository citiesDataRepository, IMapper map)
        {
            _citiesDataRepository = citiesDataRepository ?? throw new ArgumentNullException(nameof(citiesDataRepository));
            _map = map ?? throw new ArgumentNullException(nameof(map));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities(string? name)
        {
            var cityEntities = await _citiesDataRepository.GetCitiesAsync(name);

            return Ok(_map.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointOfInterest = false)
        {
            var city = await _citiesDataRepository.GetCityAsync(id, includePointOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointOfInterest)
            {
                return Ok(_map.Map<CityDto>(city));
            }

            return Ok(_map.Map<CityWithoutPointOfInterestDto>(city));
        }
    }
}