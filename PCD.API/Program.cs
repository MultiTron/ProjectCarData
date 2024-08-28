using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PCD.API;
using PCD.ApplicationServices.Implementations;
using PCD.ApplicationServices.Interfaces;
using PCD.Data;
using PCD.Repository.Implementations;
using PCD.Repository.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<DbContext, ApplicationContext>(options => options.UseSqlServer(conn, x => x.MigrationsAssembly("PCD.API")));

builder.Services.AddScoped<IUsersManagementService, UsersManagementService>();
builder.Services.AddScoped<ICarsManagementService, CarsManagementService>();
builder.Services.AddScoped<ITripsManagementService, TripsManagementService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<ITripsRepository, TripsRepository>();


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
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Car Data API",
        Description = "RESTful API for Project Car Data"

    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
});

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
