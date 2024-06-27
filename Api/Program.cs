using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Api;
using Api.Todo;
using Infrastructure.Persistence.Todos.Query;
using Integration;

var builder = WebApplication.CreateSlimBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddLogging();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddIntegration(isDevelopment);

var app = builder.Build();

app.AddTodo();

app.Run();

namespace Api
{
    [JsonSerializable(typeof(ImmutableList<TodoResponse>))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {
    }
}