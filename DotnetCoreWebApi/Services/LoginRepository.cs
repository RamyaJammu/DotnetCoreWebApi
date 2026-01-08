using DotnetCoreWebApi.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotnetCoreWebApi.SErvices
{
    public class LoginRepository : ILoginRepository
    {
        private MyDBContext _dbcontext;
        public LoginRepository(MyDBContext mydbcontext)
        {
            _dbcontext= mydbcontext;
        }
        public string GenerateToken(string UserName, string Password)
        {
            if (IsUserExists(UserName, Password))
            {
                //generate token
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JHHHJJJJJ99999NJJ33333HH55666ABCD"));
                var Credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, UserName) };
                var token = new JwtSecurityToken("https://localhost:7018", "https://localhost:7018", 
                    claims,
                expires: DateTime.Now.AddMinutes(120), signingCredentials: Credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return string.Empty;
        }


        private bool IsUserExists(string UserName,string Password)
        {
            var user=_dbcontext.Logins.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
            if(user!=null)
            {
                return true;
            }
            return false;
        }
    }
}
