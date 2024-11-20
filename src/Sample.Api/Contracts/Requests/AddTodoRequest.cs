namespace Sample.Api.Contracts.Requests;

public record AddTodoRequest
{
    public required string Description { get; init; }
}
