using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels.Security;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.Utility;

namespace WaterAMR.Business
{
    public class SecurityService : ISecurityService
    {
        private ISecurityRepository Repository;
        private IConfiguration Configuration;
        private IList<Token> TokenStore;
        public SecurityService(ISecurityRepository repository, IConfiguration config, IList<Token> tokens)
        {
            this.Repository = repository;
            this.TokenStore = tokens;
            this.Configuration = config;
            SecurityMapper.Map();
        }
        public AuthenticationResult Authenticate(string userName, string password, string clientIP, string clientBrowser)
        {
            var result = this.Repository.Authenticate(userName, password,clientIP, clientBrowser);
            if (string.IsNullOrEmpty(result.Message))
            {

                result.MenuItems = result.MenuItems== null?null:  result.MenuItems.Where(ob => ob.ParentMenuId != 0);
                var timeout = Configuration.GetSection("Authentication:SessionTimeOut").Value ?? "20";
                    Token token = new Token();
                    token.Id = Guid.NewGuid().ToString();
                token.UserId = result.User.EmployeeId;
                    token.ExpiresAt = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, Convert.ToInt32(timeout), 0));
                    this.TokenStore.Add(token);
                    result.TokenId = token.Id;
            }
            return Mapper.Map<BusinessModels.Security.AuthenticationResult>(result);
            //            return Mapper.Map < BusinessModels.Security.AuthenticationResult >(result);
        }
    }
}
