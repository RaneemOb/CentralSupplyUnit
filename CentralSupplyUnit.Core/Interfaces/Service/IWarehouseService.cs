using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Service
{
    public interface IWarehouseService
    {
        List<WarehouseDto> GetAll(int userId);
        List<WarehouseDto> GetAll();
        Warehouse GetById(int id);
        string Add(AddWarehouseDto dto, int userId);
        string Delete(List<int> ids);
        byte[] ExportWarehousesToExcel(int userId);
    }
}
