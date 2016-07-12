using System;
using System.Collections.Generic;
using System.Security.Authentication;
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

            // paths not subject to token check
            var openPaths = new List<string>()
            {
                "/api/login",
                "/api/user/create"
            };
            if (openPaths.Contains(context.Request.Path))
            {
                await _next.Invoke(context);
                return;
            }


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
                    context.Response.Redirect("/api/login");
                }
            }
            else
            {
                context.Response.Redirect("/api/login");
            }

            
                    await _next.Invoke(context);

        }
    }
}


