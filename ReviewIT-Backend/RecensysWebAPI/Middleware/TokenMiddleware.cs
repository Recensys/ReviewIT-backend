using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using RecensysWebAPI.Services;

namespace RecensysWebAPI.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            await _next.Invoke(context);
            return;

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

            // let option calls through
            var openMethods = new[] {"OPTIONS", "DEBUG"};
            if (openMethods.Contains(context.Request.Method))
            {
                await _next.Invoke(context);
                return;
            }

            

            StringValues tokens;
            
            ITokenService tokenService = new JWTTokenService();

            if (context.Request.Cookies.ContainsKey("token"))
            {
                try
                {

                    var token = context.Request.Cookies["token"];

                    var uid = tokenService.ValidateToken(token);

                    context.Items.Add("uid",uid);



                    await _next.Invoke(context);

                }
                catch (AuthenticationException)
                {
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
            }


            await _next.Invoke(context);

        }
    }
}


