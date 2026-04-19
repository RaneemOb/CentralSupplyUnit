using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Infra.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Infra.Repository
{
    public class SupplyDocumentRepository : ISupplyDocumentRepository
    {
        private readonly AppDbContext _context;

        public SupplyDocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(SupplyDocument doc)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_AddSupplyDocument @Name, @Subject, @WarehouseId, @ItemId, @CreatedBy",
                new SqlParameter("@Name", doc.Name),
                new SqlParameter("@Subject", doc.Subject),
                new SqlParameter("@WarehouseId", doc.WarehouseId),
                new SqlParameter("@ItemId", doc.ItemId),
                new SqlParameter("@CreatedBy", doc.CreatedBy)
            );
        }

        public List<SupplyDocumentDto> GetByUser(int userId)
        {
            return _context.Set<SupplyDocumentDto>()
                .FromSqlRaw("EXEC sp_GetSupplyDocumentsByUser @UserId",
                    new SqlParameter("@UserId", userId))
                .ToList();
        }

        public List<SupplyDocumentDto> GetAll()
        {
            return _context.Set<SupplyDocumentDto>()
                .FromSqlRaw("EXEC sp_GetAllSupplyDocuments")
                .ToList();
        }

        public void Approve(int id)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_ApproveSupplyDocument @Id",
                new SqlParameter("@Id", id));
        }

        public void Reject(int id)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_RejectSupplyDocument @Id",
                new SqlParameter("@Id", id));
        }

        public void Delete(int id, int userId)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_DeleteSupplyDocument @Id, @UserId",
                new SqlParameter("@Id", id),
                new SqlParameter("@UserId", userId));
        }
    
    }
}
