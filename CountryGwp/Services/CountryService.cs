using CountryGwp.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CountryGwp.Services;

public class CountryService(CountryDbContext countryDbContext) : ICountryService
{
    public async Task<IEnumerable<CountryGwpResponse>> GetDataAsync(CountryGwpRequest countryGwpRequest)
    {
        var country = await countryDbContext.Countries.FirstAsync(x => x.Name == countryGwpRequest.Country);
        var res = new List<CountryGwpResponse>();
        foreach (var item in countryGwpRequest.LOB)
        {
            var data = country.LineOfBusiness.First(x => item == x.Name);
            var lob = data.LineOfBusinessDatas.Where(x => x.Year >= 2008 && x.Year <= 2015).ToList();
            double value = 0;
            foreach (var lo in lob)
            {
                if (lo.Value == null)
                    continue;
                value += lo.Value.Value;
            }
            value /= lob.Count;
            var name = data.Name;
            res.Add(new CountryGwpResponse { Name = name, Value = value });
        }
        return res;
    }
}

