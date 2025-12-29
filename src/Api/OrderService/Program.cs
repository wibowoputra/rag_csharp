using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Configuration: load connection string
var conn = builder.Configuration.GetConnectionString("DefaultConnection") ??
           "Host=postgres;Database=postgres;Username=postgres;Password=P@ssw0rd";

// Application layer & MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Application.Orders.Commands.CreateOrderCommand)));
// Infrastructure layer: DbContext
builder.Services.AddDbContext<Infrastructure.Persistence.AppDbContext>(options =>
    options.UseNpgsql(conn));
// Repositories
builder.Services.AddScoped<Domain.Interfaces.IOrderRepository, Infrastructure.Repositories.OrderRepository>();


// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
// Apply EF migrations on startup (safe-ish for containers)
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<Infrastructure.Persistence.AppDbContext>();
//    db.Database.Migrate();
//}
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
