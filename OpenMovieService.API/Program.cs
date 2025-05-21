using Microsoft.EntityFrameworkCore; // Add this using directive for EF Core MySQL support
using OpenMovieService.Infrastructure;
using OpenMovieService.Infrastructure.Data;
using OpenMovieService.Infrastructure.DIContainer;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvcCore();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
           .AddControllerActivation();
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Use the correct overload explicitly to resolve ambiguity
((IApplicationBuilder)app).UseSimpleInjector(container);
DIContainer.RegisterServices(container);

container.Register<IHttpClientFactory>(() =>
    builder.Services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>(),
    Lifestyle.Singleton);

container.Register<HttpClient>(() =>
    container.GetInstance<IHttpClientFactory>().CreateClient(),
    Lifestyle.Scoped);


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
