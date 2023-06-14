using System.Text.Json.Serialization;

public record JsonResponse
{
    [JsonPropertyName("status")]
    public bool? Status { get; init; }

    [JsonPropertyName("result")]
    public ResponseData? Result { get; init; }
}

public record ResponseData
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("counts")]
    public CountData? Counts { get; init; }
}

public record CountData
{
    [JsonPropertyName("cases")]
    public int? Cases { get; init; }

    [JsonPropertyName("suites")]
    public int? Suites { get; init; }

    [JsonPropertyName("milestones")]
    public int? Milestones { get; init; }

    [JsonPropertyName("runs")]
    public RunData? Runs { get; init; }

    [JsonPropertyName("defects")]
    public DefectData? Defects { get; init; }
}

public record RunData
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("active")]
    public int? Active { get; init; }
}

public record DefectData
{
    [JsonPropertyName("total")]
    public int? Total { get; init; }

    [JsonPropertyName("open")]
    public int? Open { get; init; }
}