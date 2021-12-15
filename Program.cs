using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.RegularExpressions;

string serviceName = "API Galicia Seguros Template";
string serviceDescription = "Template para los microservicios de Galicia Seguros";
string serviceVersion = "v1";
bool isDevelopment;
string swaggerPrefix = "";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = serviceName,
            Description = serviceDescription,
            Version = serviceVersion,
            Contact = new OpenApiContact
            {
                Name = "Banco Galicia",
                Email = string.Empty,
                Url = new Uri("https://x.com"),
            },
        });
    options.EnableAnnotations();
    options.CustomSchemaIds(type => Regex.Replace(type.ToString(), @"[^a-zA-Z0-9._-]+", ""));
    // XML Documentation
    try
    {
        var xmlFile = "ServiceDocumentation.xml";
        // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        // var xmlPath = Path.Combine(webHostEnvironment.ContentRootPath, xmlFile);
        if (File.Exists(xmlPath))
            options.IncludeXmlComments(xmlPath);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

#region Swagger Enabled
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(swaggerPrefix == string.Empty
                    ? "/swagger/v1/swagger.json"
                    : $"/{swaggerPrefix}/swagger/v1/swagger.json", $"{serviceName} {serviceVersion}");
});
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();