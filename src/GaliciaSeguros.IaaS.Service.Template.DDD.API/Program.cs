using GaliciaSeguros.IaaS.Service.Chassis.API.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Swagger.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.HealthCheck.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Contracts;
using GaliciaSeguros.IaaS.Service.Template.DDD.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomizedSwagger(builder.Configuration, builder.Environment);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCustomizedDatabase(builder.Configuration, StorageStartup.CreateStorageStartup(builder.Services));
builder.Services.AddCustomizedHealthCheck(builder.Configuration, builder.Configuration["SQLSettings:ConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
// ----- Health check -----
app.UseCustomizedHealthCheck();
// ----- Swagger UI -----
app.UseCustomizedSwagger(app.Environment);

app.MigrationInitialization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
