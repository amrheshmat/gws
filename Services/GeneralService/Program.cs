using GWS.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.Net.Http.Headers;
using MWS.Shared;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using TripBusiness.Ibusiness;

var builder = WebApplication.CreateBuilder(args);
DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);

// Add services to the container.
builder.Services.AddDbContextsDependencies(builder.Configuration).AddBusinessDependencies().AddInfrastructureDependencies().AddGlobalDependencies();
builder.Services.AddLocalization();
builder.Services.AddControllersWithViews()
    .AddViewLocalization();
var serviceProvider = builder.Services.BuildServiceProvider();
var languageService = serviceProvider.GetRequiredService<ILanguageService>();
var languages = languageService.GetLanguages();
var cultures = languages.Select(x =>
new CultureInfo(x.code)).ToArray();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var englishCulture = cultures.FirstOrDefault(x => x.Name == "en-US");
    options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-US");

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});
builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/";
    });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10); // Set session timeout
});
builder.Services.AddAuthentication().AddCookie(options => options.LoginPath = "/");
var app = builder.Build();
var env = builder.Environment;
//Configure the HTTP request pipeline.
if (env.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Redirects to error page for 500 error
    //app.UseDeveloperExceptionPage(); // Show detailed error in dev
}
else
{
    // For production, handle errors globally without redirecting to a different page
    app.UseExceptionHandler("/Home/Error"); // Redirects to error page for 500 error
    app.UseHsts(); // Adds HTTP Strict Transport Security
}
app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

// enable the localization middleware
app.UseRequestLocalization();
//app.UseRewriter(new RewriteOptions()
//            .AddRedirectToHttps()
//            .AddRedirectToWww()
//         );
// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        var maxAge = new DateTimeOffset(DateTime.UtcNow).AddDays(30);
        ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public, max-age=2592000";
    }
});
app.UseSession();

app.UseMiddleware<JwtMiddleware>();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();
