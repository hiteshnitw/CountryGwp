using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryGwp.Models;
public class Country
{
    //[Key]
    public int CountryId { get; private init; }

    [Required]
    [StringLength(256)]
    public string Name { get; private init; }

    public List<LineOfBusiness> LineOfBusiness { get; set; }

    /// <summary>
    /// Parameter-less ctor for EF Core.
    /// </summary>
    private Country()
    {
    }

    public Country(string country)
    {
        Name = country;
    }
}
