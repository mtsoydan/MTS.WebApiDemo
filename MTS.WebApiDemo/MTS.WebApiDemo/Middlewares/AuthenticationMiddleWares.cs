using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.Middlewares
{
    public class AuthenticationMiddleWares
    {

        private readonly RequestDelegate _requestNext;

        public AuthenticationMiddleWares(RequestDelegate requestNext)
        {
            _requestNext = requestNext;
        }
        public async Task Invoke(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"];

            await _requestNext(context);
        }

    }
}
