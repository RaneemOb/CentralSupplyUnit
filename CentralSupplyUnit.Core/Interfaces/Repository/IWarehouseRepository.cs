using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Repository
{
    public interface IWarehouseRepository
    {
        List<Warehouse> GetAll();
        Warehouse GetById(int id);
        void Add(Warehouse warehouse);
        void Delete(int id);
    }
}
