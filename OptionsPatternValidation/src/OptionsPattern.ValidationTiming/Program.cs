using Microsoft.Extensions.Options;
using OptionsPattern.ValidationTiming.Configurations;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsEnvironment("SubSettingsIsFail14"))
{
    // ASPNETCORE_ENVIRONMENT:SubSettingsIsFail4
    // �ݒ��ǂݍ��񂾒���Ɍ��؂��s���ɂ́A
    // IValidateOptions<TOption>.Validate() �𖾎��I�ɌĂяo���B
}
else
{
    // �ォ�������茟�؂�����ꍇ�͈ȉ��̂悤�ɐݒ��ǂݍ��ނ̂��y�B
    var optionBuilder = builder.Services
        .AddOptions<OptionsPatternSettings>()
        .BindConfiguration(OptionsPatternSettings.ConfigurationSectionName);

    // ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 �̂Ƃ�
    // OptionBuilder<TOption>.ValidateOnStart() ���Ăяo���Ă����ƁA
    // WebApplication.Run() �����s����^�C�~���O�Ō��؂��s����B
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

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail2 �̏ꍇ
// IOptions<TOption>.Value ���Q�Ƃ���^�C�~���O�ŁA�ݒ�̌��؂��s����B
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

// ASPNETCORE_ENVIRONMENT:SubSettingsIsFail1 �̂Ƃ�
// OptionBuilder<TOption>.ValidateOnStart() ���Ăяo����Ă���΁A
// WebApplication.Run() �����s����^�C�~���O�Ō��؂��s����B
app.Run();
