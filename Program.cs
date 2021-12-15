using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "API Galicia Seguros Template",
                        Description = "Template para los microservicios de Galicia Seguros",
                        Version = "v1",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Banco Galicia",
                            Email = string.Empty,
                            Url = new Uri("https://x.com"),
                        },
                    });
    options.EnableAnnotations();
    // XML Documentation
    try
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
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
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Galicia Seguros Template");
});
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();