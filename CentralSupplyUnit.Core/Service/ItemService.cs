using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Service
{
    public class ItemService :IItemService
    {
        private readonly IItemRepository _repo;

        public ItemService(IItemRepository repo)
        {
            _repo = repo;
        }

        public List<Item> GetAll()
        {
            return _repo.GetAll();
        }

        public void Add(AddItemDto dto)
        {
            var item = new Item
            {
                Name = dto.Name,
                Description = dto.Description,
                WarehouseId = dto.WarehouseId,
                Quantity = dto.Quantity,
            };

            _repo.Add(item);
        }

        public Item GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
