var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/greetings", (string name) =>
{
    return $"Welcome {name}! Nice to meet too {name}";
})
.WithName("GetGreetings");

await app.RunAsync();
