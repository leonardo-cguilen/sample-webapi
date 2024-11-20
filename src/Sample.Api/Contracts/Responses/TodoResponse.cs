namespace Sample.Api.Contracts.Responses;

public record TodoResponse
{
    public required int Id { get; init; }

    public required string Description { get; init; }
}
