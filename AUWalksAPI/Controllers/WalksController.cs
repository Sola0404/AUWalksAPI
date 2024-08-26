using AutoMapper;
using AUWalksAPI.CustomActionFilters;
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

        // GET: /api/walks?filterOn={ColumnName}&filterQuery={Value}&sortBy={ColumnName}&isAscending=true
        // &pageNumber=1&pageSize=5
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walks = await _walkRepository.GetAllAsync(filterOn, filterQuery,
                sortBy, isAscending ?? true, pageNumber, pageSize);

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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map DTO to domain model
            var walk = _mapper.Map<Walk>(addWalkRequestDto);

            walk = await _walkRepository.CreateAsync(walk);

            // Map domain model to DTO
            var WalkDto = _mapper.Map<WalkDto>(walk);
            return Ok(WalkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walk = _mapper.Map<Walk>(updateWalkRequestDto);

            walk = await _walkRepository.UpdateAsync(id, walk);
            if (walk == null)
            {
                return NotFound();
            }

            // Map domain model to DTO
            var walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalk = await _walkRepository.DeleteAsync(id);
            if (deletedWalk == null)
            {
                return NotFound();
            }

            // Map domain model to DTO
            var walkDto = _mapper.Map<WalkDto>(deletedWalk);
            return Ok(walkDto);
        }
    }
}