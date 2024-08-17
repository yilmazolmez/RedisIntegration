using Microsoft.Extensions.Options;
using RedisIntegration.API;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var configurationOptions = new ConfigurationOptions
    {
        Password = redisSettings.Password
    };

    foreach (var endpoint in redisSettings.Endpoints)
    {
        configurationOptions.EndPoints.Add(endpoint);
    }

    return ConnectionMultiplexer.Connect(configurationOptions);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
