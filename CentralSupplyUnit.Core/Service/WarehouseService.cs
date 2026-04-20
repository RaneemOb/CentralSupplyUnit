using CentralSupplyUnit.Core.DTOs;
using CentralSupplyUnit.Core.Entities;
using CentralSupplyUnit.Core.Interfaces.Repository;
using CentralSupplyUnit.Core.Interfaces.Service;
using ClosedXML.Excel;
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

        public List<WarehouseDto> GetAll(int userId)
        {
            var data = _repo.GetAll(userId);

            var result = data
                .GroupBy(x => new
                {
                    x.WarehouseId,
                    x.WarehouseName,
                    x.Description,
                    x.CreatedDate,
                    x.CreatedByName 
                })
    .Select(g => new WarehouseDto
    {
        Id = g.Key.WarehouseId,
        Name = g.Key.WarehouseName,
        Description = g.Key.Description,
        CreatedDate = g.Key.CreatedDate,
        CreatedByName = g.Key.CreatedByName, // 🔥 هون

        Items = g
            .Where(x => x.ItemId != null)
            .Select(x => new ItemDto
            {
                Id = x.ItemId.Value,
                Name = x.ItemName,
                Description = x.ItemDescription,
                WarehouseName = x.WarehouseName,
                Quantity = x.Quantity ?? 0
            })
            .ToList()
    })
    .ToList();

            return result;
        }
        public List<WarehouseDto> GetAll()
        {
            var data = _repo.GetAll();

            var result = data
                .GroupBy(x => new
                {
                    x.WarehouseId,
                    x.WarehouseName,
                    x.Description,
                    x.CreatedDate,
                    x.CreatedByName 
                })
    .Select(g => new WarehouseDto
    {
        Id = g.Key.WarehouseId,
        Name = g.Key.WarehouseName,
        Description = g.Key.Description,
        CreatedDate = g.Key.CreatedDate,
        CreatedByName = g.Key.CreatedByName, // 🔥 هون

        Items = g
            .Where(x => x.ItemId != null)
            .Select(x => new ItemDto
            {
                Id = x.ItemId.Value,
                Name = x.ItemName,
                Description = x.ItemDescription,
                WarehouseName = x.WarehouseName,
                Quantity = x.Quantity ?? 0
            })
            .ToList()
    })
    .ToList();

            return result;
        }

        public Warehouse GetById(int id)
        {
            return _repo.GetById(id);
        }

        public string Add(AddWarehouseDto dto, int userId)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return "Warehouse name is required";

            if (dto.Items == null || dto.Items.Count == 0)
                return "At least one item is required";

            return _repo.Add(dto, userId);
        }

        public string Delete(List<int> ids)
        {
            try
            {
                _repo.Delete(ids);
                return "deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public byte[] ExportWarehousesToExcel(int userId)
        {
            var data = GetAll(userId); 

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Warehouses");

            // 🟢 Headers
            worksheet.Cell(1, 1).Value = "Warehouse Name";
            worksheet.Cell(1, 2).Value = "Description";
            worksheet.Cell(1, 3).Value = "Created By";
            worksheet.Cell(1, 4).Value = "Created Date";
            worksheet.Cell(1, 5).Value = "Item Name";
            worksheet.Cell(1, 6).Value = "Item Description";
            worksheet.Cell(1, 7).Value = "Quantity";

            int row = 2;

            foreach (var w in data)
            {
                if (w.Items != null && w.Items.Any())
                {
                    foreach (var item in w.Items)
                    {
                        worksheet.Cell(row, 1).Value = w.Name;
                        worksheet.Cell(row, 2).Value = w.Description;
                        worksheet.Cell(row, 3).Value = w.CreatedByName;
                        worksheet.Cell(row, 4).Value = w.CreatedDate;

                        worksheet.Cell(row, 5).Value = item.Name;
                        worksheet.Cell(row, 6).Value = item.Description;
                        worksheet.Cell(row, 7).Value = item.Quantity;

                        row++;
                    }
                }
                else
                {
                    worksheet.Cell(row, 1).Value = w.Name;
                    worksheet.Cell(row, 2).Value = w.Description;
                    worksheet.Cell(row, 3).Value = w.CreatedByName;
                    worksheet.Cell(row, 4).Value = w.CreatedDate;

                    row++;
                }
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}
