using System.Text.Json.Serialization;

namespace QaseServices.Project.Models.ApiResponseModels;

public record ApiProjectCaseResponse
{
    [JsonPropertyName("status")]
    public bool? Status { get; init; }

    [JsonPropertyName("result")]
    public TestResult? Result { get; init; }
}

public record TestResult
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonPropertyName("position")]
    public int? Position { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("preconditions")]
    public string? Preconditions { get; init; }

    [JsonPropertyName("postconditions")]
    public string? Postconditions { get; init; }

    [JsonPropertyName("severity")]
    public int? Severity { get; init; }

    [JsonPropertyName("priority")]
    public int? Priority { get; init; }

    [JsonPropertyName("type")]
    public int? Type { get; init; }

    [JsonPropertyName("layer")]
    public int? Layer { get; init; }

    [JsonPropertyName("is_flaky")]
    public bool? IsFlaky { get; init; }

    [JsonPropertyName("behavior")]
    public int? Behavior { get; init; }

    [JsonPropertyName("automation")]
    public int? Automation { get; init; }

    [JsonPropertyName("status")]
    public int? Status { get; init; }

    [JsonPropertyName("milestone_id")]
    public int? MilestoneId { get; init; }

    [JsonPropertyName("suite_id")]
    public int? SuiteId { get; init; }

    [JsonPropertyName("links")]
    public List<string>? Links { get; init; }

    [JsonPropertyName("custom_fields")]
    public List<object>? CustomFields { get; init; }

    [JsonPropertyName("attachments")]
    public List<object>? Attachments { get; init; }

    [JsonPropertyName("steps_type")]
    public string? StepsType { get; init; }

    [JsonPropertyName("steps")]
    public List<TestStep>? Steps { get; init; }

    [JsonPropertyName("params")]
    public List<object>? Params { get; init; }

    [JsonPropertyName("member_id")]
    public int? MemberId { get; init; }

    [JsonPropertyName("author_id")]
    public int? AuthorId { get; init; }

    [JsonPropertyName("tags")]
    public List<object>? Tags { get; init; }

    [JsonPropertyName("deleted")]
    public object? Deleted { get; init; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; init; }

    [JsonPropertyName("updated")]
    public DateTime? Updated { get; init; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }
}

public record TestStep
{
    [JsonPropertyName("hash")] public string? Hash { get; init; }

    [JsonPropertyName("position")] public int? Position { get; init; }

    [JsonPropertyName("shared_step_hash")] public object? SharedStepHash { get; init; }

    [JsonPropertyName("shared_step_nested_hash")]
    public object? SharedStepNestedHash { get; init; }

    [JsonPropertyName("attachments")] public List<object>? Attachments { get; init; }

    [JsonPropertyName("action")] public string? Action { get; init; }

    [JsonPropertyName("expected_result")] public string? ExpectedResult { get; init; }

    [JsonPropertyName("data")] public string? Data { get; init; }

    [JsonPropertyName("steps")] public string[]? Steps { get; init; }
}

   
