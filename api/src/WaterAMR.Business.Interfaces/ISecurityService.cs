using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.Security;

namespace WaterAMR.Business.Interfaces
{
    public interface ISecurityService
    {
        AuthenticationResult Authenticate(string userName, string password,string clientIP, string clientBrowser);

    }
}
