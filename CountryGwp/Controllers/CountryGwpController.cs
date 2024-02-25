using CountryGwp.Models;
using CountryGwp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountryGwp.Controllers;

/// <summary>
/// Controller with single POST endpoint used to query 
/// country's one or more lines of business (LOB)
/// </summary>
/// <param name="logger">Logger instance</param>
[ApiController]
[Route("server/api/gwp/avg")]
[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
public class CountryGwpController(ILogger<CountryGwpController> logger, ICountryService countryService) : ControllerBase
{
    
    private readonly ILogger<CountryGwpController> _logger = logger;

    /// <summary>
    /// Gets the country's one or more lines of business (LOB) data 
    /// </summary>
    /// <param name="countryGwpRequest"><see cref="CountryGwpRequest"/></param>
    /// <returns><see cref="CountryGwpResponse"/></returns>
    [HttpPost()]
    public async Task<IEnumerable<CountryGwpResponse>> Post(CountryGwpRequest countryGwpRequest) => await countryService.GetDataAsync(countryGwpRequest);
}