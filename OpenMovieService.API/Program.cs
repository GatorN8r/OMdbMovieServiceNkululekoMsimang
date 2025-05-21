using OpenMovieService.Infrastructure.DIContainer;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Integration.ServiceCollection;
using SimpleInjector.Lifestyles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvcCore();
builder.Services.AddHttpClient();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
           .AddControllerActivation();
});

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
