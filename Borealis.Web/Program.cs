//var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
//logger.Info("Init Main...");
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    //ContentRootPath = Directory.GetCurrentDirectory(),
    //EnvironmentName = Environments.Production,
    //WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Content")
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.WebHost.UseIIS();
//builder.Host.ConfigureLogging(logging =>
//{
//    logging.ClearProviders();
//    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
//    logging.AddNLogWeb();
//}).UseNLog();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseStatusCodePagesWithReExecute("/Error/HandleError/{0}/{0}");
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();