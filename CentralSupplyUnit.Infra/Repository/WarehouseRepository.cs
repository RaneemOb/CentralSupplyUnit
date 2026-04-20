using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Infra.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<WarehouseItemFlatDto> GetAll(int userId)
        {
            return _context.Set<WarehouseItemFlatDto>()
                .FromSqlRaw("EXEC sp_GetWarehousesWithItemsByUser @UserId",
                    new SqlParameter("@UserId", userId))
                .ToList();
        }
        public List<WarehouseItemFlatDto> GetAll()
        {
            return _context.Set<WarehouseItemFlatDto>()
                .FromSqlRaw("EXEC sp_GetAllWarehousesWithItems")
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

        public string Add(AddWarehouseDto dto, int userId)
        {
            var table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Quantity", typeof(int));

            foreach (var item in dto.Items)
            {
                table.Rows.Add(
                    item.Name,
                    item.Description ?? (object)DBNull.Value,
                    item.Quantity
                );
            }

            var parameters = new[]
            {
        new SqlParameter("@Name", dto.Name),
        new SqlParameter("@Description", dto.Description ?? (object)DBNull.Value),
        new SqlParameter("@CreatedBy", userId),
        new SqlParameter("@Items", table)
        {
            TypeName = "ItemTableType",
            SqlDbType = SqlDbType.Structured
        }
    };

            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC sp_AddWarehouseWithItems @Name, @Description, @CreatedBy, @Items",
                    parameters
                );

                return "Warehouse added successfully";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }

        }

        public void Delete(List<int> ids)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));

            foreach (var id in ids)
            {
                table.Rows.Add(id);
            }

            var parameter = new SqlParameter("@Ids", table)
            {
                TypeName = "IdList",
                SqlDbType = SqlDbType.Structured
            };

            _context.Database.ExecuteSqlRaw(
                "EXEC sp_DeleteWarehouses @Ids",
                parameter
            );
        }
    }
}
