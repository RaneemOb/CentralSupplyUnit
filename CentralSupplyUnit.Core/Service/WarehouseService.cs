using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Infra.Service
{
    public class WarehouseService: IWarehouseService
    {
        private readonly IWarehouseRepository _repo;

        public WarehouseService(IWarehouseRepository repo)
        {
            _repo = repo;
        }

        public List<Warehouse> GetAll()
        {
            return _repo.GetAll();
        }

        public Warehouse GetById(int id)
        {
            return _repo.GetById(id);
        }

        public string Add(Warehouse warehouse, int userId)
        {
            if (string.IsNullOrWhiteSpace(warehouse.Name))
                return "Warehouse name is required";

            warehouse.CreatedBy = userId;

            try
            {
                _repo.Add(warehouse);
                return "Warehouse added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return "Warehouse deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
