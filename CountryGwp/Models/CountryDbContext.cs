using CountryGwp.Services;
using Microsoft.EntityFrameworkCore;

namespace CountryGwp.Models;
public sealed class CountryDbContext: DbContext
{
    public DbSet<Country> Countries { get; private init; }

    public DbSet<LineOfBusiness> LineOfBusinesses { get; private init; }

    public DbSet<LineOfBusinessData> LineOfBusinessDatas { get; private init; }

    public CountryDbContext(DbContextOptions<CountryDbContext> options) :base(options)    
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LineOfBusiness>(entity =>
        {
            entity.HasOne(e => e.Country)
            .WithMany(p => p.LineOfBusiness)
            .HasForeignKey(d => d.CountryId);
        });

        modelBuilder.Entity<LineOfBusinessData>(entity =>
        {
            entity.HasOne(e => e.LineOfBusiness)
            .WithMany(p => p.LineOfBusinessDatas)
            .HasForeignKey(d => d.LineOfBusinessId);
        });
        modelBuilder.Entity<Country>().Navigation(x => x.LineOfBusiness).AutoInclude();
        modelBuilder.Entity<LineOfBusiness>().Navigation(x => x.LineOfBusinessDatas).AutoInclude();
    }

    internal void LoadData(IEnumerable<CountryEntries> data)
    {
        var dict = new Dictionary<string, CountryEntries>();
        var countries = new HashSet<Country>();
        
        foreach (var entry in data)
        {
            var country = new Country(entry.Country);
            if (countries.Contains(country))
                continue;
            countries.Add(country);
        }
                
        foreach (var entry in data)
        {
            var country = countries.First(x => x.Name == entry.Country);
            var lob = new LineOfBusiness(entry.LineOfBusiness, country);
            LineOfBusinesses.Add(lob);
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2002, 2002, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2003, 2003, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2004, 2004, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2005, 2005, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2006, 2006, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2007, 2007, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2008, 2008, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2009, 2009, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2010, 2010, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2011, 2011, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2012, 2012, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2013, 2013, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2014, 2014, lob));
            LineOfBusinessDatas.Add(new LineOfBusinessData(entry.Year2015, 2015, lob));
        }
        SaveChanges();        
    }
}

