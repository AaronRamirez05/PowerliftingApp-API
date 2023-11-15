using Powerlifting.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Injects code at runtime 
builder.Services.AddControllers();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IServiceFunctions, ServiceFunctions>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
