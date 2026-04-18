using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Repository
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        void Add(Item item);
        void Delete(int id);
    }
}
