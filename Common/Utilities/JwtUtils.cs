using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utilities
{
    public class JwtUtils
    {
        public static string GenerateToken(string email)
        {
            List<Claim> claims=new List<Claim> { new Claim("email", email) }; 
            // generate token that is valid for 7 days
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(HelperConfiguration.GetParam("JWTKey")));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMinutes(2);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
        public static string GetSaltedEmailHash(string username)
        {
            // byte[] salt = BitConverter.GetBytes(userId);
            byte[] salt = Encoding.UTF8.GetBytes(username);
            byte[] saltedPassword = new byte[salt.Length];
            Buffer.BlockCopy(salt, 0, saltedPassword, salt.Length, salt.Length);
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(saltedPassword).ToString();
        }

        public static string? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(HelperConfiguration.GetParam("JWTKey"));
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string userId = jwtToken.Claims.First(x => x.Type == "email").Value;

                // return user id from JWT token if validation successful
                return GenerateToken(userId);
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
