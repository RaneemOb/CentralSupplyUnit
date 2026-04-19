using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Repository
{
    public interface ISupplyDocumentRepository
    {
        void Add(SupplyDocument doc);

        List<SupplyDocumentDto> GetByUser(int userId);

        List<SupplyDocumentDto> GetAll();

        void Approve(int id);

        void Reject(int id);

        void Delete(int id, int userId);
    }
}
