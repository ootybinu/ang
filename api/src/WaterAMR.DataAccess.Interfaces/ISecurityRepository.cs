using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels.Security;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface ISecurityRepository
    {
        AuthenticationResult Authenticate(string userName, string password, string clientIP, string clientBrowser);
    }
}
