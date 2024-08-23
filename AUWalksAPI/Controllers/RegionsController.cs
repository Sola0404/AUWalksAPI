using AUWalksAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace AUWalksAPI.Controllers
{
    // http://localhost:5062/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AUWalksDbContext _dbContext;
        public RegionsController(AUWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // var region = _dbContext.Regions.Find(id);
            var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }
    }
}