using cube;
using Microsoft.EntityFrameworkCore;
using Namespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Pour éviter boucle de références
// builder.Services.AddControllers().AddJsonOptions(x =>
//     x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("default")));
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = null);


builder.Services.AddScoped<IRepositoryData<Service>, ServiceRepository>();
builder.Services.AddScoped<IRepositoryData<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepositoryData<Location>, LocationRepository>();
builder.Services.AddScoped<IRepositoryEmployee, EmployeeRepository>();
builder.Services.AddScoped<IRepositoryService, ServiceRepository>();
builder.Services.AddScoped<IRepositoryLocation, LocationRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<LocationService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();
app.MapControllers();
app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
