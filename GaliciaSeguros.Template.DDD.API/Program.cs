using GaliciaSegurosSvcChassis.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string svcName = builder.Configuration["Settings:ServiceName"];
string svcDescription = builder.Configuration["Settings:ServiceDescription"];
string svcVersion = builder.Configuration["Settings:ServiceVersion"];
var serviceStartup = new ServiceStartup(svcName, svcDescription, svcVersion, false);
serviceStartup.ConfigureServiceCollection(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

serviceStartup.ConfigureApplication(app, app.Services);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
