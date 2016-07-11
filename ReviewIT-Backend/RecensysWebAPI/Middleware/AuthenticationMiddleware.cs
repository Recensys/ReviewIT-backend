using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

            var token = context.Request.Headers["AuthToken"];

            if ("testToken".Equals(token))
            {
                await _next.Invoke(context);

            }
            else
            {
                context.Response.Redirect("google.dk");
            }

        }
    }
}
