using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Service
{
    public interface IItemService
    {
        List<Item> GetAll();
        Item GetById(int id);
        void Add(AddItemDto item);
        void Delete(int id);
    }
}
