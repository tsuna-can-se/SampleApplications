using Microsoft.Extensions.Options;
using OptionsPattern.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

var optionBuilder = builder.Services
    .AddOptions<OptionsPatternSettings>()
    .BindConfiguration(OptionsPatternSettings.ConfigurationSectionName)
    .ValidateDataAnnotations();

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 のときだけ
// OptionBuilder<TOption>.ValidateOnStart() を呼び出しておく。
// すると WebApplication.Run() を実行するタイミングで検証が行われる。
if (builder.Environment.IsEnvironment("SubSettingsIsFail1"))
{
    optionBuilder.ValidateOnStart();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail2 のときだけ
// Program.cs 内で IOptions<TOption>.Value を取得する。
// 値を参照するタイミングで、設定の検証も行われる。
if (app.Environment.IsEnvironment("SubSettingsIsFail2"))
{
    var options = app.Services.GetRequiredService<IOptions<OptionsPatternSettings>>();
    var setting = options.Value; // OptionsValidationException
}

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

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 のときは、
// OptionBuilder<TOption>.ValidateOnStart() が呼び出されているため、
// WebApplication.Run() を実行するタイミングで検証が行われる。
// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail3 または SettingItemIsFail のときは、
// OptionBuilder<TOption>.ValidateOnStart() が呼び出されていないため、
// IOptions<TOption>.Value を参照するまで検証が先延ばしになる。
app.Run();
