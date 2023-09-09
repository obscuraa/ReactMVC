var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = loggerFactory.CreateLogger<Program>();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}/{id}");

app.MapFallbackToFile("index.html");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run(async (context) =>
{
    logger.LogInformation($"Requested Path: {context.Request.Path}");
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
