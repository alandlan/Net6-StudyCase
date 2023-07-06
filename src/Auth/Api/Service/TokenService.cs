namespace ApiAuth.Service
{
    //public class TokenService
    //{
    //    private readonly IConfiguration _config;

    //    public TokenService(IConfiguration config)
    //    {
    //        _config = config;
    //    }
    //    public string GenerateToken(Usuario usuario)
    //    {
    //        Claim[] claims = new Claim[]{
    //            new Claim("username", usuario.UserName),
    //            new Claim("id",usuario.Id),
    //            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
    //        };

    //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
    //            _config["Jwt:Audience"],
    //            claims,
    //            expires: DateTime.Now.AddMinutes(15),
    //            signingCredentials: credentials);

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    //}
}