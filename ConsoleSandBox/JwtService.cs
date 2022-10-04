using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleSandBox
{
    public class JwtService
    {

        public static void ExecuteSecurityJwt()
        {
            Console.WriteLine("");

            byte[] _byteKey = new byte[] { 171, 66, 187, 13, 38, 81, 245, 157, 93, 9, 213, 15, 42, 70, 86, 233, 51, 50, 66, 77, 24, 88, 81, 99, 123, 219, 187, 217, 136, 76, 73, 186, 167, 61, 26, 169, 84, 149, 223, 103, 65, 183, 26, 218, 98, 92, 9, 127, 136, 235, 254, 53, 4, 2, 212, 242, 180, 75, 246, 187, 37, 225, 19, 30 };

            Console.WriteLine("Base64 encoded key:");
            Console.WriteLine(Convert.ToBase64String(_byteKey));
            Console.WriteLine();



            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            //var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(_byteKey);

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256Signature);

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var payload = new JwtPayload
           {
               ["some "] = "hello ",
               ["scope"] = "http://dummy.com/",
               ["exp"] = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600 ,
               ["iss"] = "https://rooms.docusign.com"
            };

            //
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            Console.WriteLine($"Payload time:  {secToken.Payload["exp"]}");

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);

            if(ValidateToken(tokenString, securityKey))
            {
                Console.WriteLine("Valid Token");
            }
            else
            {
                Console.WriteLine("INVALID TOKEN!");
            }


            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");


            // And finally when  you received token from client
            // you can  either validate it or try to  read
            var token = handler.ReadJwtToken(tokenString);
            //token.

            Console.WriteLine(token.Payload.First().Value);

            Console.ReadLine();
        }


        private static bool ValidateToken(string token,  SecurityKey securityKey )
        {
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingCredentials.Key,
                ValidIssuer = "https://rooms.docusign.com",
                ValidateAudience = false,
                ValidateIssuer = true,
            };

            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(token, validationParameters,  out validatedToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();

                return false;
            }

            return validatedToken != null;
        }
    }
}

