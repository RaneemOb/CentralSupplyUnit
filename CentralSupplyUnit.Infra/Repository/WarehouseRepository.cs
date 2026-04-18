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
    public class WarehouseRepository :IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Warehouse> GetAll()
        {
            return _context.Warehouses
                .FromSqlRaw("EXEC sp_GetWarehouses")
                .ToList();
        }

        public Warehouse GetById(int id)
        {
            return _context.Warehouses
                .FromSqlRaw("EXEC sp_GetWarehouseById @Id",
                    new SqlParameter("@Id", id))
                .AsEnumerable()
                .FirstOrDefault();
        }

        public void Add(Warehouse warehouse)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_AddWarehouse @Name, @Description, @CreatedBy",
                new SqlParameter("@Name", warehouse.Name),
                new SqlParameter("@Description", (object?)warehouse.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", warehouse.CreatedBy)
            );
        }

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_DeleteWarehouse @Id",
                new SqlParameter("@Id", id)
            );
        }
    }
}
