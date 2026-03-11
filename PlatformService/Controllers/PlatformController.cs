using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repositories.Platforms;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/platform")]
    public class PlatformController(
        IPlataformRepository platformRepository,
        IMapper mapper
        ) : ControllerBase
    {
        private readonly IPlataformRepository _platformRepository = platformRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms()
        {
            var response = await _platformRepository.GetAllPlatforms();

            if (response is null)
                return BadRequest(response);

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(response));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatformsById(int id)
        {
            var response = await _platformRepository.GetPlatformById(id);

            if (response is null)
                return BadRequest(response);

            return Ok(_mapper.Map<Platform>(response));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> CreatePlataform([FromBody] PlatformCreateDto platform)
        {
            var platformModel = _mapper.Map<Platform>(platform);

            await _platformRepository.CreatePlatform(platformModel);
            await _platformRepository.SaveChangesAsync();
            
            // var platformDto = _mapper.Map<PlatformReadDto>(platformModel);

            return Created();
        }
    }
}