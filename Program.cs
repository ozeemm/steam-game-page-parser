using Microsoft.AspNetCore.OpenApi;
using System.Diagnostics;
using Steam_Game_Page_Parser;
using System.Text;
using System.Xml.Linq;

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

app.MapPost("/GetGamePage", (string name) =>
{
    string url = PythonWorker.GetGameUrlByName(name);

    string fileName = PythonWorker.GetGamePageFileName(url);
    var html = File.ReadAllText(fileName);

    return Results.Text(html, "text/html");
});

app.Run();