using System.Text.Json.Serialization;

namespace QaseServices.Project.Models;

public record TestProject()
{
    [JsonPropertyName("title")]
    public string? Title { get; }
    
    [JsonPropertyName("code")]
    public string? Code { get; }

    public TestProject(string title, string code) : this()
    {
        Title = title;
        Code = code;
    }
}