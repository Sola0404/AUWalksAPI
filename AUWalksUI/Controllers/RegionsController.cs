using AUWalksUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AUWalksUI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            try
            {
                // Get all regions from web API
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("http://localhost:5062/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View(response);
        }
    }
}