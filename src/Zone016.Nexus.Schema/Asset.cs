// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Schema;

public record Asset(
    [property: JsonPropertyName("downloadUrl")] string DownloadUrl,
    [property: JsonPropertyName("path")] string Path,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("repository")] string Repository,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("checksum")] Checksum Checksum,
    [property: JsonPropertyName("contentType")] string ContentType,
    [property: JsonPropertyName("lastModified")] DateTime LastModified,
    [property: JsonPropertyName("lastDownloaded")] DateTime LastDownloaded,
    [property: JsonPropertyName("uploader")] string Uploader,
    [property: JsonPropertyName("uploaderIp")] string UploaderIp,
    [property: JsonPropertyName("fileSize")] long FileSize,
    [property: JsonPropertyName("blobCreated")] DateTime? BlobCreated,
    [property: JsonPropertyName("nuget")] NugetInfo? Nuget
);
