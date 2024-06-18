using Microsoft.Extensions.Options;
using OptionsPattern.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

var optionBuilder = builder.Services
    .AddOptions<OptionsPatternSettings>()
    .BindConfiguration(OptionsPatternSettings.ConfigurationSectionName)
    .ValidateDataAnnotations();

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 �̂Ƃ�����
// OptionBuilder<TOption>.ValidateOnStart() ���Ăяo���Ă����B
// ����� WebApplication.Run() �����s����^�C�~���O�Ō��؂��s����B
if (builder.Environment.IsEnvironment("SubSettingsIsFail1"))
{
    optionBuilder.ValidateOnStart();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail2 �̂Ƃ�����
// Program.cs ���� IOptions<TOption>.Value ���擾����B
// �l���Q�Ƃ���^�C�~���O�ŁA�ݒ�̌��؂��s����B
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

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 �̂Ƃ��́A
// OptionBuilder<TOption>.ValidateOnStart() ���Ăяo����Ă��邽�߁A
// WebApplication.Run() �����s����^�C�~���O�Ō��؂��s����B
// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail3 �܂��� SettingItemIsFail �̂Ƃ��́A
// OptionBuilder<TOption>.ValidateOnStart() ���Ăяo����Ă��Ȃ����߁A
// IOptions<TOption>.Value ���Q�Ƃ���܂Ō��؂��扄�΂��ɂȂ�B
app.Run();
