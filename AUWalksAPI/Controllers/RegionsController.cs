using AutoMapper;
using AUWalksAPI.Models.Domain;
using AUWalksAPI.Models.DTO;
using AUWalksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AUWalksAPI.Controllers
{
    // http://localhost:5062/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // get data from database - domain models
            var regions = await _regionRepository.GetAllAsync();

            // map domain models to DTOs
            var regionsDto = _mapper.Map<List<RegionDto>>(regions);

            // return DTOs
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // get region domain model from database
            // var region = _dbContext.Regions.Find(id);
            var region = await _regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            // Map region domain model to region DTO
            var regionDto = _mapper.Map<RegionDto>(region);

            // Return Dto back to client
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO to domain model
            var region = _mapper.Map<Region>(addRegionRequestDto);

            // Use domain model to create Region
            region = await _regionRepository.CreateAsync(region);

            // Map domain model back to DTO
            var regionDto = _mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var region = _mapper.Map<Region>(updateRegionRequestDto);

            region = await _regionRepository.UpdateAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            // Map domain model to Dto
            var regionDto = _mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }
    }
}