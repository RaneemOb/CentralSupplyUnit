using CentralSupplyUnit.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.Interfaces.Service
{
    public interface ISupplyDocumentService
    {
        void Add(AddSupplyDocumentDto dto, int userId);

        List<SupplyDocumentDto> GetByUser(int userId);

        List<SupplyDocumentDto> GetAll();

        void Approve(int id);

        void Reject(int id);

        void Delete(int id, int userId);
    }
}
