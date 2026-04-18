using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Service
{
    public interface IAuthService
    {
        string Login(string username, string password);
    }
}
