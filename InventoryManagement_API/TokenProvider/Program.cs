
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

const string issuer = "TokenProvider";
const string audience = "InventoryManagement_API";
const string signInKey = "sdgdsgsssssssssssssssssssssssssssssssdgsdgsd";


var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey));

var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


var claim = new Claim[]
{
    new Claim(ClaimTypes.Name, "Reedham"),
    new Claim(ClaimTypes.Role, "SalesRep"),
    new Claim(ClaimTypes.Email, "Reedham@Reedham.com"),
};

var token = new JwtSecurityToken(
       issuer: issuer,
          audience: audience,
          claims: claim,
          signingCredentials: credentials
       );

Console.WriteLine(new JwtSecurityTokenHandler().WriteToken(token));

