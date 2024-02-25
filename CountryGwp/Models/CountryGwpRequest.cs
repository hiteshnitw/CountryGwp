using JsonRequiredAttribute = Newtonsoft.Json.JsonRequiredAttribute;

namespace CountryGwp.Models;

/// <summary>
/// Request class needed to query data
/// </summary>
public sealed class CountryGwpRequest
{
    /// <summary>
    /// Name of country to query
    /// </summary>
    public required string Country {  get; set; }

    /// <summary>
    /// LOBs to query
    /// </summary>
    public required string[] LOB { get; set; }
}

public sealed class CountryGwpResponse
{
    /// <summary>
    /// Name of country to query
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// LOBs to query
    /// </summary>
    public required double Value { get; set; }
}

