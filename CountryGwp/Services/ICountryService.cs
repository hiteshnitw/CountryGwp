using CountryGwp.Models;

namespace CountryGwp.Services;
public interface ICountryService
{
    Task<IEnumerable<CountryGwpResponse>> GetDataAsync(CountryGwpRequest countryGwpRequest);
}
