using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Service
{
    public interface IWarehouseService
    {
        List<Warehouse> GetAll();
        Warehouse GetById(int id);
        string Add(Warehouse warehouse, int userId);
        string Delete(int id);
    }
}
