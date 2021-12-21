using GaliciaSeguros.IaaS.Service.Chassis.API.Contracts;
using GaliciaSeguros.IaaS.Service.Template.DDD.API.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Swagger.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomizedSwagger(builder.Configuration, builder.Environment);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var serviceStartup =
    new ServiceStartup(
        false,
         StorageStartup.CreateStorageStartup(builder.Services),
         builder.Configuration,
         builder.Environment);
serviceStartup.ConfigureServiceCollection(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseCustomizedSwagger(app.Environment);

serviceStartup.ConfigureApplication(app, app.Services);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
