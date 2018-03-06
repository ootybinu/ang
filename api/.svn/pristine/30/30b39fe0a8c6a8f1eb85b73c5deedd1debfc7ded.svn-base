using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using WaterAMR.BusinessModels.Security;
using WaterAMR.Utility;

namespace WaterAMR.API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticateMiddleware
    {

        private readonly RequestDelegate _next;
        private IList<Token> TokenStore;
        private Int32 SessionTimeOut;
        private string Exceptions = "values,ping,security";

        public AuthenticateMiddleware(RequestDelegate next, IList<Token> tokens, Int32 sessionTimeOut)
        {
            _next = next;
            TokenStore = tokens;
            SessionTimeOut = sessionTimeOut;
        }

        public Task Invoke(HttpContext httpContext)
        {
            CheckExpirations();
            if (IsAuthenticationRequired(httpContext.Request.Path))
            {
                var header = httpContext.Request.Headers["Autherization"];
                var current = TokenStore.Where(tok => tok.Id == header);
                if (current.Any())
                {
                    current.FirstOrDefault().ExpiresAt = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, SessionTimeOut, 0));
                    return _next(httpContext);
                }
                else {
                    httpContext.Response.StatusCode = 440;
                    httpContext.Response.WriteAsync("Invalid/Expired Token");
                    
                }
            }

            return _next(httpContext);
        }

        private bool IsAuthenticationRequired(PathString path)
        {
            bool result = true;
            var pat = path.ToString().ToLower();
            var r = Exceptions.Split(',');
            for (int i = 0; i < r.Count(); i++)
            {
                if (pat.Contains(r[i]))
                    {
                    return false;
                }
            }
            return result; 
        }

        public void CheckExpirations()
        {
            var list = TokenStore.Where(ob => ob.ExpiresAt < DateTime.Now.TimeOfDay);
            if (list.Any())
            {
                list.ToList().ForEach(m => TokenStore.Remove(m));
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticateMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticateMiddleware>();
        }
    }
}
