using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.DTOs
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public List<ItemDto> Items { get; set; } = new();
    }
}
