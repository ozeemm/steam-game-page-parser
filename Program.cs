var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles(); // Отправка статических веб-страниц по умолчанию без обращения к ним по полному пути
app.UseStaticFiles(); // обрабатывает все запросы к wwwroot

app.Run();