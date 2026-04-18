using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        User GetByCredentials(string username, string password);
    }
}
