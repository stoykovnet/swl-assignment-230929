using PetStore.Mappers;

var builder = WebApplication.CreateBuilder(args);

//TODO: Add localhost database connection

var app = builder.Build();

builder.Services.AddAutoMapper(typeof(BaseProfile));
builder.Services.AddSwaggerDocument();
builder.Services.AddLogging();
builder.Services.AddApplicationInsightsTelemetry(opt =>
{
    opt.InstrumentationKey = builder.Configuration.GetSection("ApplicationInsights")["InstrumentationKey"];
});
builder.Services.AddControllers();

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();