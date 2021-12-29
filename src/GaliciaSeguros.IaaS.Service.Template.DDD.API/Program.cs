using GaliciaSeguros.IaaS.Service.Chassis.API.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Swagger.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.HealthCheck.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Contracts;
using GaliciaSeguros.IaaS.Service.Template.DDD.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomizedSwagger(builder.Configuration, builder.Environment);
builder.Services.AddCustomizedDatabase(builder.Configuration, StorageStartup.CreateStorageStartup(builder.Services));
#if (AddHealthCheck)
builder.Services.AddCustomizedHealthCheck(builder.Configuration, builder.Configuration["SQLSettings:ConnectionString"]);
#endif
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
#if (AddHealthCheck)
app.UseCustomizedHealthCheck();
#endif
// ----- Swagger UI -----
app.UseCustomizedSwagger(app.Environment);

app.MigrationInitialization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
