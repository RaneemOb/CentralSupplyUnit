using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Repository
{
    public interface IWarehouseRepository
    {
        List<WarehouseItemFlatDto> GetAll(int userId);
        List<WarehouseItemFlatDto> GetAll();
        Warehouse GetById(int id);
        string Add(AddWarehouseDto dto, int userId);
        void Delete(List<int> ids);
    }
}
