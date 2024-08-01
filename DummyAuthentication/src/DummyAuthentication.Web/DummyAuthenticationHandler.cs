using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace DummyAuthentication.Web;

internal class DummyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public DummyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
        : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // ダミーのユーザー名とロール名を設定します。
        Claim[] claims = [
            new Claim(ClaimTypes.Name, "dummy_user"),
            new Claim(ClaimTypes.Role, "Admin")
        ];
        var identity = new ClaimsIdentity(claims, this.Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, this.Scheme.Name);

        // 認証は常に成功させます。
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
