var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
