namespace Zone016.Nexus.Schema;

public record Proxy(
    [property: JsonPropertyName("remoteUrl")] string RemoteUrl
);
