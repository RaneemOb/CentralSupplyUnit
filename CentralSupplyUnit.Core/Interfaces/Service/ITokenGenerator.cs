using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Service
{
    public interface ITokenGenerator
    {
        string Generate(User user);
    }
}
