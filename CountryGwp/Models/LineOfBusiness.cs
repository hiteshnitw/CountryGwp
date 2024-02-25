using System.ComponentModel.DataAnnotations;

namespace CountryGwp.Models;

public class LineOfBusiness
{
    public LineOfBusiness(string? lineOfBusiness, Country country)
    {
        Name = lineOfBusiness;
        Country = country;
    }

    //[Key]
    public int LineOfBusinessId { get; private init; }
    public string Name { get; private init; }
    public int CountryId { get; private init; }

    public Country Country { get; private init; }

    public List<LineOfBusinessData> LineOfBusinessDatas { get; set; }

    /// <summary>
    /// Parameter-less ctor for EF Core.
    /// </summary>
    private LineOfBusiness()
    {
    }
}
