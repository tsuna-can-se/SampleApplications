using DummyAuthentication.Web;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    // ���[�J���J�����ł̃_�~�[�̔F�؃n���h���[��o�^���܂��B
    builder.Services.AddAuthentication("DummyAuthentication")
        .AddScheme<AuthenticationSchemeOptions, DummyAuthenticationHandler>("DummyAuthentication", null);
    builder.Services.AddAuthorization();
}
else if (builder.Environment.IsProduction())
{
    // �{�Ԋ��ł̔F�؃n���h���[�͂����œo�^���܂��B
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

// �F�؃~�h���E�F�A��ǉ����܂��B
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
