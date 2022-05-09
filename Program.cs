using Kursach;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.UseStaticFiles();


app.UseHttpsRedirection();


ApplicationContext db = new ApplicationContext();
db.Users.Clear();
db.SaveChanges();

app.MapControllers();



app.Run();
