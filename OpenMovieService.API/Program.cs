using SimpleInjector.Lifestyles;
using SimpleInjector;
using SimpleInjector.Integration.ServiceCollection; // Add this using directive
using SimpleInjector.Integration.AspNetCore; // Add this using directive
using SimpleInjector.Integration.AspNetCore.Mvc; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
           .AddControllerActivation(); // Ensure this extension method is available
});

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
