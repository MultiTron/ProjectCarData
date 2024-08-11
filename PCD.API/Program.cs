using Microsoft.EntityFrameworkCore;
using PCD.API;
using PCD.ApplicationServices.Implementations;
using PCD.ApplicationServices.Interfaces;
using PCD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn, x => x.MigrationsAssembly("PCD.API")));

builder.Services.AddScoped<IUsersManagementService, UsersManagementService>();
builder.Services.AddScoped<ICarsManagementService, CarsManagementService>();

builder.Services.AddHttpClient("TollApi", client =>
{
    client.BaseAddress = builder.Configuration.GetValue<Uri>("TollAPIUrl");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
