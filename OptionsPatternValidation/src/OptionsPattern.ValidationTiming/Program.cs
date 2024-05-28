using Microsoft.Extensions.Options;
using OptionsPattern.ValidationTiming.Configurations;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsEnvironment("SubSettingsIsFail14"))
{
    // ASPNETCORE_ENVIRONMENT:SubSettingsIsFail4
    // 設定を読み込んだ直後に検証を行うには、
    // IValidateOptions<TOption>.Validate() を明示的に呼び出す。
}
else
{
    // 後からゆっくり検証をする場合は以下のように設定を読み込むのが楽。
    var optionBuilder = builder.Services
        .AddOptions<OptionsPatternSettings>()
        .BindConfiguration(OptionsPatternSettings.ConfigurationSectionName);

    // ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 のとき
    // OptionBuilder<TOption>.ValidateOnStart() を呼び出しておくと、
    // WebApplication.Run() を実行するタイミングで検証が行われる。
    if (builder.Environment.IsEnvironment("SubSettingsIsFail1"))
    {
        optionBuilder.ValidateOnStart();
    }

    builder.Services.AddSingleton<IValidateOptions<OptionsPatternSettings>, OptionsPatternSettingsValidator>();
    builder.Services.AddSingleton<IValidateOptions<SubSettings>, SubSettingsValidator>();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail2 の場合
// IOptions<TOption>.Value を参照するタイミングで、設定の検証も行われる。
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

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 のとき
// OptionBuilder<TOption>.ValidateOnStart() が呼び出されていれば、
// WebApplication.Run() を実行するタイミングで検証が行われる。
app.Run();
