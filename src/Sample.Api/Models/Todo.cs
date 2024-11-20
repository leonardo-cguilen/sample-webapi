namespace Sample.Api.Models;

public record Todo
{
    public required int Id { get; init; }

    public required string Description { get; init; }

    public DateTime CreatedAt { get; init; }
}
