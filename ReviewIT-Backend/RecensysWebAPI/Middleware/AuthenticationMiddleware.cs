using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RecensysWebAPI.Services;

namespace RecensysWebAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            /*
            var token = context.Request.Headers["AuthToken"];

            ITokenService tokenService = new JWTTokenService();

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    tokenService.ValidateToken(token);


                    // continue with any other middleware
                    await _next.Invoke(context);

                }
                catch (AuthenticationException e)
                {
                    context.Response.Redirect("login");
                }
            }
            else
            {
                context.Response.Redirect("login");
            }

            */
                    await _next.Invoke(context);

        }
    }
}


