// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.
namespace Zone016.Boxer.Schema;

public record Challenge
{
    [JsonPropertyName("id")] public required int Id { get; init; }
    [JsonPropertyName("name")] public required string Name { get; init; }
    [JsonPropertyName("creator_id")] public int? CreatorId { get; init; }
    [JsonPropertyName("state")] public string? State { get; init; }
    [JsonPropertyName("difficulty")] public string? Difficulty { get; init; }
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("category_name")] public string? CategoryName { get; init; }
    [JsonPropertyName("first_blood_user")] public string? FirstBloodUser { get; init; }
    [JsonPropertyName("first_blood_time")] public string? FirstBloodTime { get; init; }
    [JsonPropertyName("creator_name")] public string? CreatorName { get; init; }
    [JsonPropertyName("creator_avatar")] public string? CreatorAvatar { get; init; }
    [JsonPropertyName("sha256")] public string? Sha256 { get; init; }
    [JsonPropertyName("docker_ip")] public string? DockerIp { get; init; }
    [JsonPropertyName("likes")] public int? Likes { get; init; }
    [JsonPropertyName("dislikes")] public int? Dislikes { get; init; }
    [JsonPropertyName("retired")] public bool Retired { get; init; }
    [JsonPropertyName("points")] public int Points { get; init; }
    [JsonPropertyName("difficulty_chart")] public DifficultyChart? DifficultyChart { get; init; }
    [JsonPropertyName("solves")] public required int Solves { get; init; }
    [JsonPropertyName("stars")] public double Stars { get; init; }
    [JsonPropertyName("isRespected")] public bool IsRespected { get; init; }
    [JsonPropertyName("download")] public bool Download { get; init; }
    [JsonPropertyName("docker")] public bool Docker { get; init; }
    [JsonPropertyName("docker_ports")] public string? DockerPorts { get; init; }
    [JsonPropertyName("release_date")] public DateTime ReleaseDate { get; init; }
    [JsonPropertyName("released")] public int Released { get; init; }
    [JsonPropertyName("authUserSolve")] public bool AuthUserSolve { get; init; }
    [JsonPropertyName("likeByAuthUser")] public bool LikeByAuthUser { get; init; }
    [JsonPropertyName("isTodo")] public bool IsTodo { get; init; }
    [JsonPropertyName("recommended")] public int Recommended { get; init; }
    [JsonPropertyName("user_can_review")] public bool UserCanReview { get; init; }

    [JsonPropertyName("first_blood_user_id")]
    public int FirstBloodUserId { get; init; }

    [JsonPropertyName("authUserSolveTime")]
    public string? AuthUserSolveTime { get; init; }

    [JsonPropertyName("first_blood_user_avatar")]
    public string? FirstBloodUserAvatar { get; init; }

    [JsonPropertyName("dislikeByAuthUser")]
    public bool DislikeByAuthUser { get; init; }

    [JsonPropertyName("authUserHasReviewed")]
    public bool AuthUserHasReviewed { get; init; }
}
