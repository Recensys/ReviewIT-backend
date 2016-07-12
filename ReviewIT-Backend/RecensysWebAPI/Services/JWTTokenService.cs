using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecensysWebAPI.Services
{
    public class JWTTokenService : ITokenService
    {
        public string GetToken(int uid)
        {

            var payload = new Dictionary<string, object>()
            {
                { "uid", uid },
            };

            var secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrK";
            string token = JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256);
            return token;
        }

        public int ValidateToken(string token)
        {
            var secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrK";
            try
            {
                var jsonPayload = JWT.JsonWebToken.DecodeToObject(token, secretKey) as IDictionary<string, object>;
                return (int)jsonPayload["uid"];
            }
            catch (JWT.SignatureVerificationException)
            {
                Console.WriteLine("Invalid token!");
            }
            return -1;
        }
    }
}
