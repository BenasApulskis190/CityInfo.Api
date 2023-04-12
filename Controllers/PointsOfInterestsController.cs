using AutoMapper;
using CityInfo.Api.Models;
using CityInfo.Api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly ILogger<PointOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        public PointOfInterestController(
            ILogger<PointOfInterestController> logger,
            IMailService mailService,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper
            )
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService
                ?? throw new ArgumentNullException(nameof(mailService));
            _cityInfoRepository = cityInfoRepository
                ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                _logger.LogInformation($"City dos not exists with an id {cityId}");
                return NotFound();
            }
            var pointsOfInterest = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterest));
        }

        [HttpGet("{pointOfInterestsId}", Name = "GetPointOfInterests")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestsId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestsId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int cityId, PointOfInterestsForCreatingDto pointOfInterests
            )
        {

            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }


            var finalPoint = _mapper.Map<Entities.PointOfInterest>(pointOfInterests);

            await _cityInfoRepository.AddPointOfInterestForCityAsync(cityId, finalPoint);

            await _cityInfoRepository.SaveChangesAsync();

            var createdPointOfInterest = _mapper.Map<Models.PointOfInterestDto>(finalPoint);

            return CreatedAtRoute("GetPointOfInterests", new
            {
                cityId,
                pointOfInterestsId = createdPointOfInterest.Id
            }, createdPointOfInterest);
        }

        [HttpPut("{pointOfInterestsId}")]
        public async Task<ActionResult<PointOfInterestDto>> UpdatePointOfInterestDto(
            int cityId,
            int pointOfInterestsId,
            PointOfInterestsForUpdateDto pointOfInterest
            )
        {


            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestsId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterestEntity, pointOfInterest);
            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{pointOfInterestsId}")]
        public async Task<ActionResult<PointOfInterestDto>> PartiallyUpdatePointOfInterest(
            int cityId,
            int pointOfInterestsId,
            JsonPatchDocument<PointOfInterestsForUpdateDto> patchDocument
            )
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestsId);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestsToPatch = _mapper.Map<PointOfInterestsForUpdateDto>(pointOfInterestEntity);

            patchDocument.ApplyTo(pointOfInterestsToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(pointOfInterestsToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(pointOfInterestsToPatch, pointOfInterestEntity);

            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{pointOfInterestsId}")]
        public async Task<ActionResult> DeletePointOfInterests(int cityId, int pointOfInterestsId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestsFromEntity = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestsId);
            if (pointOfInterestsFromEntity == null)
            {
                return NotFound();
            }


            _cityInfoRepository.DeletePointOfInterest(pointOfInterestsFromEntity);
            await _cityInfoRepository.SaveChangesAsync();

            _mailService.Send($"{pointOfInterestsFromEntity.Name}", $"Was deleted {pointOfInterestsFromEntity.Id}");
            return NoContent();
        }
    }
}