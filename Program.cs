using Kursach;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.UseStaticFiles();


app.UseHttpsRedirection();





app.MapControllers();



app.Run();
