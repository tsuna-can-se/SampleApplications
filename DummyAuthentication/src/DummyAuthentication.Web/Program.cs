using DummyAuthentication.Web;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    // ローカル開発環境でのダミーの認証ハンドラーを登録します。
    builder.Services.AddAuthentication("DummyAuthentication")
        .AddScheme<AuthenticationSchemeOptions, DummyAuthenticationHandler>("DummyAuthentication", null);
    builder.Services.AddAuthorization();
}
else if (builder.Environment.IsProduction())
{
    // 本番環境での認証ハンドラーはここで登録します。
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 認証ミドルウェアを追加します。
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
