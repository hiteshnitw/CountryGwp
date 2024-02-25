using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryGwp.Models;

public class LineOfBusinessData
{
    //[Key]
    public int Id { get; private init; }
    public double? Value { get; private init; }
    public int Year { get; private init; }

    public int LineOfBusinessId { get; private init; }
    public LineOfBusiness LineOfBusiness { get; private init; }

    /// <summary>
    /// Parameter-less ctor for EF Core.
    /// </summary>
    private LineOfBusinessData()
    {
    }

    public LineOfBusinessData(double? value, int year, LineOfBusiness lineOfBusiness)
    {
        Value = value;
        Year = year;
        LineOfBusiness = lineOfBusiness;
    }
}
