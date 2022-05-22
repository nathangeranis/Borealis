var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
logger.Info("Init Main...");
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ApplicationName = typeof(Program).Assembly.GetName().Name,
    ContentRootPath = Directory.GetCurrentDirectory(),
#if DEBUG
    EnvironmentName = Environments.Development,
#else
    EnvironmentName = Environments.Production,
#endif
    WebRootPath = Directory.GetCurrentDirectory()
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.Configure<MudTheme>(builder.Configuration.GetSection(nameof(MudTheme)));
builder.Services.AddDataServices(builder.Configuration);
builder.WebHost.UseIIS();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    logging.AddNLogWeb();
}).UseNLog();


var app = builder.Build();
// Configure the HTTP request pipeline.
#if DEBUG
app.UseDeveloperExceptionPage();
#else 
app.UseExceptionHandler("/Error");
app.UseHsts();
#endif
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseStatusCodePagesWithReExecute("/Error/HandleError/{0}/{0}");
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();