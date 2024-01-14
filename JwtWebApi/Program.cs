using Microsoft.EntityFrameworkCore;
using JwtWebApi.Data;
using JwtWebApi.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JwtWebApiContextConnection") ?? throw new InvalidOperationException("Connection string 'JwtWebApiContextConnection' not found.");

builder.Services.AddDbContext<JwtWebApiContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<JwtWebApiUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<JwtWebApiContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "deafult",
    pattern: "{controller=Home}/{action=Index}/{id}");
app.Run();
