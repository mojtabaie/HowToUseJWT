using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestJWT.Models;

namespace TestJWT
{
    public class JWTAuthorizationManager
    {
        public JwtResponse? Authenticate(string username, string password)
        {
            if(username != "myuser" || password != "pass12345")
            {
                return null;
            }

            //ایجاد تاریخ انقضا توکن
            var tokenExpireTimeStamp = DateTime.Now.AddHours(Constants.JWT_TOKEN_EXPIRE_TIME);

            //ایجاد متغیر از کلاس مشخص شده برای ایجاد توکن و اطلاعات همراه آن
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //ایجاد آرایه ای از بایت ها به عنوان کلید توکن
            var tokenkey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY_FOR_TOKEN);

            //از این کلاس برای نگهداری ویژگی ها و اطلاعات درون توکن استفاده می شود
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),
                Expires = tokenExpireTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature),

            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new JwtResponse
            {
                Token = token,
                UserName = username,
                Expire = (int)tokenExpireTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
