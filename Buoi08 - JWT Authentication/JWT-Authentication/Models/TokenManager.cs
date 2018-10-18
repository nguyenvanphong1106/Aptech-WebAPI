using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace JWT_Authentication
{
    public class TokenManager
    {
        //HMACSHA256 hmac = new HMACSHA256();
        //string key = Convert.ToBase64String(hmac.Key);
        public static string SecrectKey = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";

        
        public static string GenerateToken(string username)
        {            
            byte[] key = Convert.FromBase64String(SecrectKey);

            //create a SymmetricSecurityKey object
            SymmetricSecurityKey securitykey = new SymmetricSecurityKey(key);

            //creating the descriptor object, represents the main content of the JWT: 
            //the claims
            //the expiration date
            //the signing information
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature)           
            };

            //the token is created and a string version of it is returned
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }


        //read, validate the token and create a ClaimsPrincipal object --> holds the user’s identity
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                //reads the token in string format and converts it into a JwtSecurityToken
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken) tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;

                //creating the key again
                byte[] key = Convert.FromBase64String(SecrectKey);

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }


        //add or modify things, depending on the data that you send in the tokens
        //this method creates the Principal OBJECT using the token and then extracts the Identity object out of it
        //This OBJECT contains all the claims from the token, based on the claim type
        public static string ValidateToken(string token)
        {
            string username = null;

            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;

            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            return username;
        }
    }
}
