using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.MapControllers();
app.Run();
