using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace CountryGwp.Services;
public class CSVImporter
{
    public static IEnumerable<CountryEntries> Import()
    {        
        using (var reader = new StreamReader("gwpByCountry.csv"))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CountryEntries>();
                return records.ToList(); 
            }
        }
    }
}

/// <summary>
/// TODO: Way we load year data is poor. 
/// Need to manage this better.
/// </summary>
public class CountryEntries
{
    [Index(0)]
    public string Country { get; set; }

    [Index(3)]
    public string? LineOfBusiness { get; set; }

    [Index(4)]
    public double? Year2000 { get; set; }

    [Index(5)]
    public double? Year2001 { get; set; }

    [Index(6)]
    public double? Year2002 { get; set; }

    [Index(7)]
    public double? Year2003 { get; set; }

    [Index(8)]
    public double? Year2004 { get; set; }

    [Index(9)]
    public double? Year2005 { get; set; }

    [Index(10)]
    public double? Year2006 { get; set; }

    [Index(11)]
    public double? Year2007 { get; set; }

    [Index(12)]
    public double? Year2008 { get; set; }

    [Index(13)]
    public double? Year2009 { get; set; }

    [Index(14)]
    public double? Year2010 { get; set; }

    [Index(15)]
    public double? Year2011 { get; set; }

    [Index(16)]
    public double? Year2012 { get; set; }

    [Index(17)]
    public double? Year2013 { get; set; }

    [Index(18)]
    public double? Year2014 { get; set; }

    [Index(19)]
    public double? Year2015 { get; set; }
}
