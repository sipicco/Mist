using Mist.Backend.Middlewares;
using Mist.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration(); // Add secrets to the config
builder.AddDbConnection();

builder.AddStandardServices();
builder.AddCustomServices();

builder.AddAuthentication();

// Build app
var app = builder.Build();

// Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
