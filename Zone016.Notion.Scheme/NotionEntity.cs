namespace Zone016.Notion.Scheme;

public record NotionEntity
{
    [JsonPropertyName("id")] public required string Id { get; init; }
    [JsonPropertyName("object")] public required string Object { get; init; }
    [JsonPropertyName("created_time")] public required DateTime CreatedAt { get; init; }
    [JsonPropertyName("last_edited_time")] public required DateTime LastTimeEditedAt { get; init; }
    
    [JsonPropertyName("properties")] public required Dictionary<string, JsonNode> Properties { get; init; }
}
