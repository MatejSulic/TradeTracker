using Microsoft.EntityFrameworkCore;
using TradeTracker.API.Data;


var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Přidej DbContext
builder.Services.AddDbContext<TradeTrackerDbContext>(options =>
    options.UseSqlite("Data Source=TradeTracker.db"));

// 2️⃣ Přidej podporu pro controllery
builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

// 5️⃣ Map controllers
app.MapControllers();

app.Run();
