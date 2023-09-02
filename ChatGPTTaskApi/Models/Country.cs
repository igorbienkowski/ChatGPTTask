namespace ChatGPTTaskApi.Models;

public class Country
{
    public Name Name { get; set; }
    public List<string> Tld { get; set; }
    public string Cca2 { get; set; }
    public string Ccn3 { get; set; }
    public string Cca3 { get; set; }
    public bool Independent { get; set; }
    public string Status { get; set; }
    public bool UnMember { get; set; }
    public Dictionary<string, Currency> Currencies { get; set; }
    public Idd Idd { get; set; }
    public List<string> Capital { get; set; }
    public List<string> AltSpellings { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public Dictionary<string, string> Languages { get; set; }
    public Dictionary<string, Translation> Translations { get; set; }
    public List<double> Latlng { get; set; }
    public bool Landlocked { get; set; }
    public double Area { get; set; }
    public Dictionary<string, Demonym> Demonyms { get; set; }
    public string Flag { get; set; }
    public Maps Maps { get; set; }
    public int Population { get; set; }
    public Car Car { get; set; }
    public List<string> Timezones { get; set; }
    public List<string> Continents { get; set; }
    public Flags Flags { get; set; }
    public CoatOfArms CoatOfArms { get; set; }
    public string StartOfWeek { get; set; }
    public CapitalInfo CapitalInfo { get; set; }
    public PostalCode PostalCode { get; set; }
}