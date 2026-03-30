using ConversionSystem.API.Infrastructures;
using ConversionSystem.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(x =>
{
    x.Filters.Add<ConversionExceptionFiltr>();
}).AddControllersAsServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.GetSwaggerDocument();
builder.Services.AddDependencies();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<ConversionSystemContext>(options => options.UseNpgsql(conString), ServiceLifetime.Scoped);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.GetSwaggerDocumnetUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

