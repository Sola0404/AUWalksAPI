using AutoMapper;
using AUWalksAPI.Models.Domain;
using AUWalksAPI.Models.DTO;
using AUWalksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AUWalksAPI.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _walkRepository.GetAllAsync();

            // Map domain model to DTO
            var walkDtos = _mapper.Map<List<WalkDto>>(walks);
            return Ok(walkDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _walkRepository.GetByIdAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            // Map domain model to DTO
            var walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to domain model
            var walk = _mapper.Map<Walk>(addWalkRequestDto);

            walk = await _walkRepository.CreateAsync(walk);

            // Map domain model to DTO
            var WalkDto = _mapper.Map<WalkDto>(walk);
            return Ok(WalkDto);
        }
    }
}