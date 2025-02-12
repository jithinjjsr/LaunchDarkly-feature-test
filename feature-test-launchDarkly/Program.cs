using LaunchDarkly.Sdk.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Replace with your LaunchDarkly SDK Key
var sdkKey = "";

// Add LaunchDarkly Client
builder.Services.AddSingleton<LdClient>(sp =>
{
    var config = Configuration.Builder(sdkKey).Build();
    return new LdClient(config);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
