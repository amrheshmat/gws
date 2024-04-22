using GWS.Service;
using Microsoft.AspNetCore.Localization;
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
// enable the localization middleware
app.UseRequestLocalization();
//app.UseRewriter(new RewriteOptions()
//            .AddRedirectToHttps()
//            .AddRedirectToWww()
//         );
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseMiddleware<JwtMiddleware>();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
