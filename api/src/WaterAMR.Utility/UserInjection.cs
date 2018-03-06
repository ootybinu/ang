using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WaterAMR.Utility
{
    public class UserInjection : IUserInjection
    {
        private IHttpContextAccessor Context;
        private IList<Token> tokens;
        public UserInjection(IHttpContextAccessor _ctx , IList<Token> _tokens)
        {
            Context = _ctx;
            tokens = _tokens;
        }
        public int GetUser()
        {
            var current = Context.HttpContext.Request.Headers["Autherization"];

            var user = (from tok in tokens
                        where tok.Id == current
                        select tok).FirstOrDefault();
            return user == null ? 0 : user.UserId;
        }
    }
}
