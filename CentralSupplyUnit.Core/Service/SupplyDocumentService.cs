using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Enums;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Service
{
    public class SupplyDocumentService : ISupplyDocumentService
    {
        private readonly ISupplyDocumentRepository _repo;

        public SupplyDocumentService(ISupplyDocumentRepository repo)
        {
            _repo = repo;
        }

        public void Add(AddSupplyDocumentDto dto, int userId)
        {
            var doc = new SupplyDocument
            {
                Name = dto.Name,
                Subject = dto.Subject,
                WarehouseId = dto.WarehouseId,
                ItemId = dto.ItemId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                Status = SupplyDocumentStatus.Pending
            };

            _repo.Add(doc);
        }

        public List<SupplyDocumentDto> GetByUser(int userId)
        {
            return _repo.GetByUser(userId);
        }

        public List<SupplyDocumentDto> GetAll()
        {
            return _repo.GetAll();
        }

        public void Approve(int id)
        {
            _repo.Approve(id);
        }

        public void Reject(int id)
        {
            _repo.Reject(id);
        }

        public void Delete(int id, int userId)
        {
            _repo.Delete(id, userId);
        }
    

    }
}
