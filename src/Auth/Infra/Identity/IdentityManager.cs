using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Net6StudyCase.Auth.Domain;
using Net6StudyCase.SharedKernel.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net6StudyCase.Auth.Infra.Identity
{
    public class IdentityManager : IIdentityManager
    {
        private UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;

        public IdentityManager(UserManager<Usuario> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        public async Task Cadastrar(Usuario user,string password, UserTypeEnum userType)
        {
            var response = await _userManager.CreateAsync(user, password);

            if (response.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("UserType", UserType.GetUserType(userType)));
            }
        }

        public async Task<string?> GenerateToken(Usuario usuario)
        {
            var claims = await _userManager.GetClaimsAsync(usuario);
            var userRoles = await _userManager.GetRolesAsync(usuario);

            if (!claims.Any(c => c.Type == JwtRegisteredClaimNames.Name))
                claims.Add(new Claim(JwtRegisteredClaimNames.Name, usuario.NormalizedUserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            claims.Add(new Claim("Jti", Guid.NewGuid().ToString()));
            claims.Add(new Claim("Nbf", ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim("Iat", ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
                claims.Add(new Claim("role", userRole));


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");    

            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = _config["Jwt:Audience"],
                Issuer = _config["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddSeconds(300)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
