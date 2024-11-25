using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Auth;

public class JwtHandler : IJwtHandler
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly JwtOptions _jwtOptions;
    private readonly SecurityKey _issuerSigningKey;
    private readonly SigningCredentials _signingCredentials;
    private readonly JwtHeader _jwtHeader;
    private readonly TokenValidationParameters _tokenValidationParameters;
    public JwtHandler(IOptions<JwtOptions> jwtOptions)
    {
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        _jwtOptions = jwtOptions.Value;
        _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
        _jwtHeader = new JwtHeader(_signingCredentials);
        _tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidIssuer = _jwtOptions.Issuer,
            IssuerSigningKey = _issuerSigningKey,
        };

    }
    public JsonWebToken Create(long userId)
    {
        var nowUtc = DateTime.UtcNow;
        var expires = nowUtc.AddMinutes(_jwtOptions.ExpiryMinutes);
        var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
        var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalMilliseconds);
        var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalMilliseconds);

        var payload = new JwtPayload
        {
            {"sub",userId},
            {"iss",_jwtOptions.Issuer },
            {"iat",now },
            {"exp",exp},
            {"unique_code",userId}
        };

        var jwt = new JwtSecurityToken(_jwtHeader, payload);
        var token = _jwtSecurityTokenHandler.WriteToken(jwt);

        return new JsonWebToken
        {
            Token = token,
            Expires = exp,
        };
    }
}
