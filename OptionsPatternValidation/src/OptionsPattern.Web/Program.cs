using Microsoft.Extensions.Options;
using OptionsPattern.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<OptionsPatternSettings>()
    .Bind(builder.Configuration.GetSection(OptionsPatternSettings.ConfigurationSectionName));

builder.Services.AddSingleton<IValidateOptions<OptionsPatternSettings>, OptionsPatternSettingsValidator>();
builder.Services.AddSingleton<IValidateOptions<SubSettings>, SubSettingsValidator>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
