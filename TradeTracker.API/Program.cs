using Microsoft.EntityFrameworkCore;
using TradeTracker.API.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            // Povolí požadavky POUZE z adresy Klienta (http://localhost:5017)
            policy.WithOrigins("http://localhost:5017") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Přidání DbContext + SQLite
builder.Services.AddDbContext<TradeTrackerDbContext>(options =>
    options.UseSqlite("Data Source=TradeTracker.db"));

// Přidání controllerů
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TradeTracker API", Version = "v1" });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TradeTracker API v1"));
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
