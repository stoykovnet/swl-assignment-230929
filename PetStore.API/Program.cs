using PetStore.DataAccessLayer;
using PetStore.DataAccessLayer.Repositories;
using PetStore.DataAccessLayer.Repositories.Interfaces;
using PetStore.Mappers;

var builder = WebApplication.CreateBuilder(args);

//TODO: Add localhost database connection

builder.Services.AddAutoMapper(typeof(BaseProfile));
builder.Services.AddSwaggerDocument();
builder.Services.AddLogging();
builder.Services.AddApplicationInsightsTelemetry(opt =>
{
    opt.InstrumentationKey = builder.Configuration.GetSection("ApplicationInsights")["InstrumentationKey"];
});
builder.Services.AddControllers();

// Repositories.
builder.Services.AddDbContext<PetStoreContext>();
builder.Services.AddScoped<IPetRepository, PetRepository>();

var app = builder.Build();

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();