using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddHttpLogging(logging =>
{
    // Configure logging options
    logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
                            HttpLoggingFields.ResponsePropertiesAndHeaders;
    logging.RequestBodyLogLimit = 4096; // Limit request body size to log
    logging.ResponseBodyLogLimit = 4096; // Limit response body size to log
});

var app = builder.Build();

app.MapOpenApi();

app.UseHttpLogging(); // Enable the middleware

var handler = new sqltest.Program();

app.MapGet("/little", handler.Lookup);

app.Run();

