using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SearchService.Interface;
using SearchService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly ISearchApiClient searchApi;
        private readonly ILogger logger;

        public SearchController(ILogger<SearchController> _logger, ISearchApiClient _searchApi)
        {
            this.searchApi = _searchApi;
            this.logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSearchLocationAsync(string address)
        {
            try
            {
                if (string.IsNullOrEmpty(address))
                    throw new ArgumentNullException("Address parameter is required!");

                var locationResults = await searchApi.GetSearchAsync(address);

                if (locationResults.Count > 0)
                    return Ok(locationResults);
                else
                    return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.LogError(ex, "Request validation error!");
                return BadRequest();
            }
            catch (UnauthorizedAccessException)
            {
                this.logger.LogError("Unauthorized access!");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Internal server error!");
                return StatusCode(500);
            }
        }


    }
}
