using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles(); // Отправка статических веб-страниц по умолчанию без обращения к ним по полному пути
app.UseStaticFiles(); // обрабатывает все запросы к wwwroot

app.MapGet("/test", () => 
{
    
});

app.Run();