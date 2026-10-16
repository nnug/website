using System.Globalization;
using Microsoft.AspNetCore.Localization;
using NNUG.WebSite.Core.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();

if (builder.Configuration.GetValue<bool>("UseDesignTimeData"))
{
    builder.Services.AddSingleton<IHttpGetStringCommand, HttpGetStringFromEmbeddedResourceCommand>();
}
else
{
    builder.Services.AddHttpClient<IHttpGetStringCommand, HttpGetStringCommand>();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

var norwegian = new CultureInfo("nb-NO");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(norwegian),
    SupportedCultures = [norwegian],
    SupportedUICultures = [norwegian]
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
