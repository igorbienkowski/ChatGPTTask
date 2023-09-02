using ChatGPTTaskApi.Services;

namespace ChatGPTTaskApi.Models;

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NativeName> NativeName { get; set; }
}